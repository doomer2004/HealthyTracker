using AutoMapper;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public class GoogleAuthService : AuthServiceBase, IGoogleAuthService
{
    private readonly GoogleConfig _googleConfig;
    private readonly IMapper _mapper;
    private readonly UserRegistrationRepository _userRegistrationRepository;
    
    public GoogleAuthService
        (UserManager<User> userManager, JwtConfig jwtConfig, ILogger<AuthServiceBase> logger,
            UserRegistrationRepository userRegistrationRepository, GoogleConfig googleConfig, IMapper mapper)
        : base(userManager, jwtConfig, logger)
    {
        _userRegistrationRepository = userRegistrationRepository;
        _googleConfig = googleConfig;
        _mapper = mapper;
    }

    public async Task<Either<ErrorDTO, AuthSuccessDTO>> SignUpAsync(string authorizationCode)
    {
        var payload = await GetGooglePayloadAsync(authorizationCode);

        var user = await _userManager.FindByEmailAsync(payload.Email);

        if (user is not null)
            return new AlreadyExistsErrorDTO("User with this email already exists");

        user = _mapper.Map<User>(payload);

        user.EmailConfirmed = true;
        var createUserResult = await _userManager.CreateAsync(user);

        if (!createUserResult.Succeeded)
        {
            _logger.LogIdentityError(user, createUserResult);
            return new IdentityErrorDTO("Unable to create user");
        }

        return await GenerateAuthResultAsync(user);
    }

    public async Task<Either<ErrorDTO, AuthSuccessDTO>> SignInAsync(string authorizationCode)
    {
        var payload = await GetGooglePayloadAsync(authorizationCode);
        var user = await _userManager.FindByEmailAsync(payload.Email);

        if (user is null)
            return new NotFoundErrorDTO("User not found");

        if (!user.EmailConfirmed)
        {
            user.EmailConfirmed = true;
            var updateUserResult = await _userManager.UpdateAsync(user);

            var userRegistration = await _userRegistrationRepository.Get(user.Id);
            
            if (userRegistration != null)
                await _userRegistrationRepository.Delete(userRegistration);

            if (!updateUserResult.Succeeded)
            {
                _logger.LogIdentityError(user, updateUserResult);
                return new IdentityErrorDTO("Unable to update user");
            }
        }
        return await GenerateAuthResultAsync(user);
    }

    private async Task<GoogleJsonWebSignature.Payload> GetGooglePayloadAsync(string authorizationCode)
    {
        var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
            {
                ClientId = _googleConfig.ClientId,
                ClientSecret = _googleConfig.ClientSecret
            }
        });
        
        var tokenResponse = await flow.ExchangeCodeForTokenAsync(
            string.Empty,
            authorizationCode,
            _googleConfig.RedirectUri,
            CancellationToken.None);
        
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new List<string> { _googleConfig.ClientId },
            IssuedAtClockTolerance = _googleConfig.ClockTolerance,
            ExpirationTimeClockTolerance = _googleConfig.ClockTolerance,
        };
            
        var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken, settings);
        return payload;
    }
    
}
