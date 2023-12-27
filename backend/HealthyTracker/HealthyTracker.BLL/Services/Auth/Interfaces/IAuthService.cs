using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IAuthService
{
    Task<Either<ErrorDTO, SignUpResponseDTO>> SignUpAsync(SignUpDTO dto);
    Task<Either<ErrorDTO, AuthSuccessDTO>> SignInAsync(SignInDTO dto);
}