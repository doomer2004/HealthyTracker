using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IGoogleAuthService
{
    Task<Either<ErrorDto, AuthSuccessDTO>> SignUpAsync(string authorizationCode);
    Task<Either<ErrorDto, AuthSuccessDTO>> SignInAsync(string authorizationCode);
}