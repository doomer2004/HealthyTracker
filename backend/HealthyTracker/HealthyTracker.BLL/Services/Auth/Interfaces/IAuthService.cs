using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IAuthService
{
    Task<Either<ErrorDto, SignUpResponseDto>> SignUpAsync(SignUpDTO dto);
    Task<Either<ErrorDto, AuthSuccessDTO>> SignInAsync(SignInDTO dto);
}