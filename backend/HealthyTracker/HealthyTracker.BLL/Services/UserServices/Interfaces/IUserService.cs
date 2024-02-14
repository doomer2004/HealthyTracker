using System.Security.Claims;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using LanguageExt;
using Microsoft.AspNetCore.Http;

namespace HealthyTracker.BLL.Services.UserServices.Interfaces;

public interface IUserService
{
    Task<Either<ErrorDto, UserDTO>> GetByIdAsync(Guid id, string apiUrl);
    Task<Either<ErrorDto, UserDTO>> GetByClaimsPrincipalAsync(ClaimsPrincipal user, string apiUrl);
    Task<Guid?> GetByClaimPrincipalAsync(ClaimsPrincipal user, string apiUrl);
    Task<Either<ErrorDto, UserDTO>> UpdateUserAsync(Guid id, UpdateUserDTO dto, string apiUrl);
    Task<Option<ErrorDto>> UploadAvatarAsync(Guid userId, IFormFile stream);
    Task<Option<ErrorDto>> DeleteAvatarAsync(Guid userId);
}