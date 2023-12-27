using HealthyTracker.Common.Models.Utility;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IUserRegistrationService
{
    Task<Option<ErrorModel>> CanConfirmEmailAsync(Guid userId, string url);
    Task<Either<ErrorModel, string>> RegenerateEmailConfirmationUrlAsync(Guid userId);
    Task<Either<ErrorModel, string>> GenerateEmailConfirmationUrlAsync(Guid userId);
}