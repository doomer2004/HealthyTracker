using System.Web;
using HealthyTracker.BLL.Services.Auth.Auth;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.Utility;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.UserServices.Services;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly IUserRegistrationRepository _userRegistrationRepository;
    private readonly AuthConfig _authConfig;
    private readonly UserManager<User> _userManager;
    private readonly CallbackUrisConfig _urisConfig;

    public UserRegistrationService(IUserRegistrationRepository userRegistrationRepository, AuthConfig authConfig,
        UserManager<User> userManager, CallbackUrisConfig urisConfig) 
    {
        _userRegistrationRepository = userRegistrationRepository;
        _authConfig = authConfig;
        _userManager = userManager;
        _urisConfig = urisConfig;
    }
    
    public async Task<Option<ErrorModel>> CanConfirmEmailAsync(Guid userId, string url)
    {
        var registration = await _userRegistrationRepository.Table
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (registration is null)
            return new ErrorModel("You have not requested email confirmation");
        
        if (registration.ExpiresAt < DateTimeOffset.UtcNow)
            return new ErrorModel("Confirmation code has expired. Please request a new one");

        await _userRegistrationRepository.Delete(registration);
        return Option<ErrorModel>.None;
    }

    public async Task<Either<ErrorModel, string>> RegenerateEmailConfirmationUrlAsync(Guid userId)
    {
        var registration = await _userRegistrationRepository.Table
            .FirstOrDefaultAsync(r => r.UserId == userId);
        
        if (registration is null)
            return new ErrorModel("You have not requested email confirmation");

        if (registration.IsUrlRegenerated)
            return new ErrorModel("You have already requested a new url");
        
        registration.Url = (string) await GenerateEmailConfirmationUrlAsync(userId);
        registration.ExpiresAt = DateTimeOffset.UtcNow.Add(_authConfig.ConfirmationUrlLifetime);
        registration.IsUrlRegenerated = true;
        await _userRegistrationRepository.Update(registration);
        
        return registration.Url;
    }

    public async Task<Either<ErrorModel, string>> GenerateEmailConfirmationUrlAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encodedToken = HttpUtility.UrlEncode(token);
        var callbackUrl = string.Format(_urisConfig.ResetPasswordUriTemplate, user.Email, encodedToken);

        return callbackUrl;
    }
}