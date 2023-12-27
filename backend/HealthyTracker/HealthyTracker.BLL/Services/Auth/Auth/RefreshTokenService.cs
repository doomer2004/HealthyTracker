using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public class RefreshTokenService : AuthServiceBase, IRefreshTokenService
{
    private readonly TokenValidationParameters _tokenValidationParameters;
    
    public RefreshTokenService(UserManager<User> userManager, JwtConfig jwtConfig, ILogger<AuthServiceBase> logger,
        TokenValidationParameters tokenValidationParameters) : base(userManager, jwtConfig, logger)
    {
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<Either<ErrorDTO, AuthSuccessDTO>> RefreshTokenAsync(RefreshTokenDTO dto)
    {
        var option = GetPrincipalFromToken(dto.AccessToken);
        return await option.MatchAsync(
            Some: async validateToken =>
            {
                var expiryDateUnix =
                    long.Parse(validateToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(expiryDateUnix);

                if (expiryDateTimeUtc > DateTime.UtcNow)
                    return new IncorrectParametersErrorDTO("Access token is not expired yet");

                var user = await _userManager.FindByIdAsync(validateToken.Claims.Single(x => x.Type == "id").Value);
                if (user is null)
                    return new IncorrectParametersErrorDTO("User with this id does not exist");

                if (DateTimeOffset.UtcNow > user.RefreshTokenExpiryTime)
                    return new ExpiredErrorDTO("Refresh token is expired");

                if (user.RefreshToken != dto.RefreshToken)
                    return new IncorrectParametersErrorDTO("Refresh token is invalid");

                return await GenerateAuthResultAsync(user);
            },
            None: () => new IncorrectParametersErrorDTO("Access token is invalid")
        );
    }

    private Option<ClaimsPrincipal> GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = _tokenValidationParameters.Clone();
        validationParameters.ValidateLifetime = false;

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return HasValidSecurityAlgorithm(validatedToken) ? principal : Option<ClaimsPrincipal>.None;
        }
        catch (Exception e)
        {
            return Option<ClaimsPrincipal>.None;
        }
    }

    private bool HasValidSecurityAlgorithm(SecurityToken token)
    {
        return token is JwtSecurityToken jwtSecurityToken &&
               jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }
}