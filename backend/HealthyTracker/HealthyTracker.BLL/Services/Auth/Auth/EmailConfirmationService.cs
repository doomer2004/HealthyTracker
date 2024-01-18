using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Email.Models;
using HealthyTracker.Email.Services.Interfaces;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public class EmailConfirmationService : AuthServiceBase, IEmailConfirmationService
{
    private readonly IEmailSender _emailSender;
    private readonly IUserRegistrationService _userRegistrationService;
    public EmailConfirmationService(UserManager<User> userManager, JwtConfig jwtConfig, 
        ILogger<AuthServiceBase> logger, IEmailSender emailSender, IUserRegistrationService userRegistrationService) 
        : base(userManager, jwtConfig, logger)
    {
        _emailSender = emailSender;
        _userRegistrationService = userRegistrationService;
    }

    public async Task<Either<ErrorDto, AuthSuccessDTO>> ConfirmEmailAsync(ConfirmEmailDTO dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        if (user.EmailConfirmed)
            return new IncorrectParametersErrorDTO("Email is already confirmed");
        
        var option = await _userRegistrationService.CanConfirmEmailAsync(dto.UserId, dto.Url);
        return await option.Match<Task<Either<ErrorDto, AuthSuccessDTO>>>(
            None: async () =>
            {
                user.EmailConfirmed = true;
                var userUpdated = await _userManager.UpdateAsync(user);
                if (!userUpdated.Succeeded)
                {
                    _logger.LogIdentityError(user, userUpdated);
                    return new IdentityErrorDTO("Unable to confirm email. Please try again later");
                }

                _logger.LogInformation("Email confirmed for user: {0}", user.Id);
                return await GenerateAuthResultAsync(user);
            },
            Some: error =>
            {
                _logger.LogError("Unable to confirm email for user: {0}, error: {1}", user.Id, error.Message);
                return Task.FromResult<Either<ErrorDto, AuthSuccessDTO>>(
                    new IncorrectParametersErrorDTO(error.Message));
            });
    }

    public async Task<Option<ErrorDto>> ResendConfirmationCodeAsync(ResendConfirmationUrlDTO dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        var result = await _userRegistrationService.RegenerateEmailConfirmationUrlAsync(dto.UserId);
        
        return await result.Match<Task<Option<ErrorDto>>>(
            Right: async url =>
            {
                var emailSent = await _emailSender.SendEmailAsync(user.Email!,
                    new EmailConfirmationMessage { Url = url });

                return emailSent.Match<Option<ErrorDto>>(
                    None: () =>
                    {
                        _logger.LogInformation("Email confirmation code sent to user {0}", user.Id);
                        return Option<ErrorDto>.None;
                    },
                    Some: error =>
                    {
                        _logger.LogError("Unable to send email confirmation code to user {0}", user.Id);
                        return new ExternalErrorDTO(error.Message);
                    }
                );
            },
            Left: error =>
            {
                _logger.LogError("Unable to generate email confirmation code for user {0}, error: {1}", user.Id,
                    error.Message);

                return Task.FromResult<Option<ErrorDto>>(new IncorrectParametersErrorDTO(error.Message));
            });
    }
}