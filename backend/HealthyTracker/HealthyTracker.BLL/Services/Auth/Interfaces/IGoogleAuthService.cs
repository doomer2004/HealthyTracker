using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IGoogleAuthService
{
    Task<Either<ErrorDTO, AuthSuccessDTO>> SignUpAsync(string authorizationCode);
    Task<Either<ErrorDTO, AuthSuccessDTO>> SignInAsync(string authorizationCode);
}