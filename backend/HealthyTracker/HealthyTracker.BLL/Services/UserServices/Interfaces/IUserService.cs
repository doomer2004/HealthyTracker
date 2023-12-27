using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using LanguageExt;
using Microsoft.AspNetCore.Http;

namespace HealthyTracker.BLL.Services.Auth.Interfaces;

public interface IUserService
{
    Task<Either<ErrorDTO, UserDTO>> GetByIdAsync(Guid id, string apiUrl);
    Task<Either<ErrorDTO, UserDTO>> UpdateUserAsync(Guid id, UpdateUserDTO dto, string apiUrl);
    Task<Option<ErrorDTO>> UploadAvatarAsync(Guid userId, IFormFile stream);
    Task<Option<ErrorDTO>> DeleteAvatarAsync(Guid userId);
}