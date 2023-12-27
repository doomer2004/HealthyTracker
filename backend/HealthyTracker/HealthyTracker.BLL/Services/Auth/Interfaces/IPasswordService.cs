using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IPasswordService
{
    Task<Option<ErrorDTO>> ChangePasswordAsync(Guid userId, ChangePasswordDTO dto);
    Task<Option<ErrorDTO>> ForgotPasswordAsync(ForgotPasswordDTO dto);
    Task<Option<ErrorDTO>> ResetPasswordAsync(ResetPasswordDTO dto);
    Task<Option<ErrorDTO>> AddPasswordAsync(Guid userId, AddPasswordDTO dto);
}