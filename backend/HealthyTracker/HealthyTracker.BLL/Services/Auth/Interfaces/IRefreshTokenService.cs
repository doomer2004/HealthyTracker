using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IRefreshTokenService
{
    Task<Either<ErrorDto, AuthSuccessDTO>> RefreshTokenAsync(RefreshTokenDTO dto);
}