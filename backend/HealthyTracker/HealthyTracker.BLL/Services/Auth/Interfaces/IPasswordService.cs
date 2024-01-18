using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using LanguageExt;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IPasswordService
{
    Task<Option<ErrorDto>> ChangePasswordAsync(Guid userId, ChangePasswordDTO dto);
    Task<Option<ErrorDto>> ForgotPasswordAsync(ForgotPasswordDTO dto);
    Task<Option<ErrorDto>> ResetPasswordAsync(ResetPasswordDTO dto);
    Task<Option<ErrorDto>> AddPasswordAsync(Guid userId, AddPasswordDTO dto);
}