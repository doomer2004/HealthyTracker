using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Utility;
using HealthyTracker.Common.Enums;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HealthyTracker.BLL.Services.Auth.Auth;

public abstract class AuthServiceBase
{
    private readonly JwtConfig _jwtConfig;
    protected readonly UserManager<User> _userManager;
    protected readonly ILogger<AuthServiceBase> _logger;

    protected AuthServiceBase(UserManager<User> userManager, JwtConfig jwtConfig, ILogger<AuthServiceBase> logger)
    {
        _jwtConfig = jwtConfig;
        _userManager = userManager;
        _logger = logger;
    }

    protected async Task<Either<ErrorDTO, AuthSuccessDTO>> GenerateAuthResultAsync(User user)
    {
        var options = await GenerateTokenAsync(user);
        var accessToken = await GenerateJwtTokenAsync(user);
        return options.Match<Either<ErrorDTO, AuthSuccessDTO>>(
            Right: refreshToken => new AuthSuccessDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            },
            Left: errorCode => new ErrorDTO(errorCode, "Unable to generate refresh token")
        );
    }

    private async Task<string> GenerateJwtTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtConfig.AccessTokenLifetime),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }
    private async Task<Either<ErrorCode, string>> GenerateTokenAsync(User user)
    {
        user.RefreshToken = TokenGenerator.GenerateToken();
        user.RefreshTokenExpiryTime = DateTimeOffset.UtcNow.Add(_jwtConfig.RefreshTokenLifetime);
        var userUpdated = await _userManager.UpdateAsync(user);
        if (!userUpdated.Succeeded)
        {
            _logger.LogIdentityError(user, userUpdated);
            return ErrorCode.IdentityError;
        }
        
        return user.RefreshToken;
    }
}