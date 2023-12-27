using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IEmailConfirmationService
{
    Task<Either<ErrorDTO, AuthSuccessDTO>> ConfirmEmailAsync(ConfirmEmailDTO dto);
    Task<Option<ErrorDTO>> ResendConfirmationCodeAsync(ResendConfirmationUrlDTO dto);
}