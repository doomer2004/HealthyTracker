using System.Web;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Email.Models;
using HealthyTracker.Email.Services.Interfaces;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public class PasswordService : AuthServiceBase, IPasswordService
{
    private readonly IEmailSender _emailSender;
    private readonly CallbackUrisConfig _urisConfig;
    
    public PasswordService(UserManager<User> userManager, JwtConfig jwtConfig,
        ILogger<AuthServiceBase> logger, IEmailSender emailSender, CallbackUrisConfig urisConfig) 
        : base(userManager, jwtConfig, logger)
    {
        _emailSender = emailSender;
        _urisConfig = urisConfig;
    }

    public async Task<Option<ErrorDTO>> ChangePasswordAsync(Guid userId, ChangePasswordDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(userId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.OldPassword);
        if (!isPasswordValid)
            return new IncorrectParametersErrorDTO("Old password is incorrect");

        var isPasswordSame = await _userManager.CheckPasswordAsync(user, dto.NewPassword);
        if (isPasswordSame)
            return new IncorrectParametersErrorDTO("New password have to differ from the old one");

        var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (!result.Succeeded)
        {
            _logger.LogIdentityError(user, result);
            return new IdentityErrorDTO("Unable to change password");
        }

        var emailSent = await _emailSender.SendEmailAsync(user.Email!,
            new PasswordChangedMessage {UserName = user.DisplayName});

        return emailSent.Match<Option<ErrorDTO>>(
            None: () =>
            {
                _logger.LogInformation("Password changed email sent to user: {0}", user.Id);
                return Option<ErrorDTO>.None;
            },
            Some: error =>
            {
                _logger.LogError("Unable to send email to user: {0}", user.Id);
                return new ExternalErrorDTO(error.Message);
            }
        );
    }

    public async Task<Option<ErrorDTO>> ForgotPasswordAsync(ForgotPasswordDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return new NotFoundErrorDTO("User with this email does not exist");

        if (!user.EmailConfirmed)
            return new IncorrectParametersErrorDTO("Your email is not confirmed yet");
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encodedToken = HttpUtility.UrlEncode(token);
        var callbackUrl = string.Format(_urisConfig.ResetPasswordUriTemplate, user.Email, encodedToken);
        
        var emailSent = await _emailSender.SendEmailAsync(user.Email!,
            new ResetPasswordMessage { UserName = user.DisplayName, ResetPasswordUrl = callbackUrl });

        return emailSent.Match<Option<ErrorDTO>>(
            None: () =>
            {
                _logger.LogInformation("Forgot password email sent to user: {0}", user.Id);
                return Option<ErrorDTO>.None;
            },
            Some: error =>
            {
                _logger.LogError("Unable to send email to user: {0}", user.Id);
                return new ExternalErrorDTO(error.Message);
            }
        );
    }

    public async Task<Option<ErrorDTO>> ResetPasswordAsync(ResetPasswordDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return new NotFoundErrorDTO("User with this email does not exist");
        
        if (!user.EmailConfirmed)
            return new IncorrectParametersErrorDTO("Your email is not confirmed yet");
        
        var isSamePassword = await _userManager.CheckPasswordAsync(user, dto.NewPassword);
        if (isSamePassword)
            return new IncorrectParametersErrorDTO("New password have to differ from the old one");
        
        var decodedToken = HttpUtility.UrlDecode(dto.Token);
        var result = await _userManager.ResetPasswordAsync(user, decodedToken, dto.NewPassword);
        if (!result.Succeeded)
        {
            _logger.LogIdentityError(user, result);
            return new IdentityErrorDTO("Unable to reset password");
        }
        
        var emailSent = await _emailSender.SendEmailAsync(user.Email!,
            new PasswordChangedMessage { UserName = user.DisplayName });
        
        return emailSent.Match<Option<ErrorDTO>>(
            None: () =>
            {
                _logger.LogInformation("Password changed email sent to user: {0}", user.Id);
                return Option<ErrorDTO>.None;
            },
            Some: error =>
            {
                _logger.LogError("Unable to send email to user: {0}", user.Id);
                return new ExternalErrorDTO(error.Message);
            }
        );
    }

    public async Task<Option<ErrorDTO>> AddPasswordAsync(Guid userId, AddPasswordDTO dto)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");
        
        if (user.PasswordHash is not null)
            return new IncorrectParametersErrorDTO("You already have a password");
        
        var result = await _userManager.AddPasswordAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            _logger.LogIdentityError(user, result);
            return new IdentityErrorDTO("Unable to add password");
        }
        
        _logger.LogInformation("Password added to user: {0}", user.Id);
        return Option<ErrorDTO>.None;
    }
}