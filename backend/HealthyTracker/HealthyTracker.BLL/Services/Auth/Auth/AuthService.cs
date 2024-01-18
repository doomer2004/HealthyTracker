using AutoMapper;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Client.Nutrition;
using HealthyTracker.Common.Models;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Email.Models;
using HealthyTracker.Email.Services.Interfaces;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public class AuthService : AuthServiceBase, IAuthService
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IUserRegistrationService _userRegistrationService;
    
    public AuthService(
        UserManager<User> userManager,
        JwtConfig jwtConfig,
        ILogger<AuthServiceBase> logger,
        IMapper mapper,
        IEmailSender emailSender,
        IUserRegistrationService userRegistrationService)
        : base(userManager, jwtConfig, logger)
    {
        _mapper = mapper;
        _emailSender = emailSender;
        _userRegistrationService = userRegistrationService;
    }

    public async Task<Either<ErrorDto, SignUpResponseDto>> SignUpAsync(SignUpDTO dto)
    {
        
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is not null)
            return new AlreadyExistsErrorDTO("User with this email already exists");
           
        
        user = _mapper.Map<User>(dto);
        var createdUser = await _userManager.CreateAsync(user, dto.Password);
        if (!createdUser.Succeeded)
        {
            _logger.LogIdentityError(user, createdUser);
            return new IdentityErrorDTO(
                "Unable to create a user. Please try again later or use another email address");
        }

        var generateUrl = await _userRegistrationService.GenerateEmailConfirmationUrlAsync(user.Id);
        return await generateUrl.Match<Task<Either<ErrorDto, SignUpResponseDto>>>(
            Right: async url =>
            {
                var emailSent = await _emailSender.SendEmailAsync(user.Email!,
                    new EmailConfirmationMessage() {Url = url});

                return emailSent.Match<Either<ErrorDto, SignUpResponseDto>>(
                    None: () =>
                    {
                        _logger.LogInformation("Email confirmation url sent to user {0}", user.Id);
                        return new SignUpResponseDto {UserId = user.Id};
                    },
                    Some: error =>
                    {
                        _logger.LogError("Unable to send email confirmation url to user {0}", user.Id);
                        return new ExternalErrorDTO(error.Message);
                    });
            },
            Left: error =>
            {
                _logger.LogError("Unable to generate email confirmation url for user {0}, error: {1}", user.Id,
                    error.Message);

                return Task.FromResult<Either<ErrorDto, SignUpResponseDto>>(
                    new IncorrectParametersErrorDTO(error.Message));
            });
    }

    public async Task<Either<ErrorDto, AuthSuccessDTO>> SignInAsync(SignInDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return new NotFoundErrorDTO("User with this email does not exist");
        
        if (!user.EmailConfirmed)
            return new IncorrectParametersErrorDTO("Confirm your email before signing in");
        
        var validPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!validPassword)
            return new IncorrectParametersErrorDTO("Email or password is incorrect");
        
        return await GenerateAuthResultAsync(user);
    }
}