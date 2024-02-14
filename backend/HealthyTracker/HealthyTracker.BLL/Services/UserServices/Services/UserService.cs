using System.Security.Claims;
using AutoMapper;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.BLL.Services.UserServices.Interfaces;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.User;
using HealthyTracker.Common.Models.Utility;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Email.Services.Interfaces;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyTracker.BLL.Services.UserServices.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly AppDataConfig _appData;

    public UserService(IMapper mapper, ILogger<UserService> logger, UserManager<User> userManager, AppDataConfig appData)
    {
        _mapper = mapper;
        _logger = logger;
        _userManager = userManager;
        _appData = appData;
    }

    public async Task<Either<ErrorDto, UserDTO>> GetByClaimsPrincipalAsync(ClaimsPrincipal user, string apiUrl)
    {
        var currentUser = await _userManager.GetUserAsync(user);
        if (currentUser is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        return ToDto<UserDTO>(currentUser, apiUrl);
    }
    
    public async Task<Guid?> GetByClaimPrincipalAsync(ClaimsPrincipal user, string apiUrl)
    {
        var currentUser =  await _userManager.GetUserAsync(user);
        // currentUser.
        
    
        return await Task.FromResult(currentUser?.Id);
    }
    public async Task<Either<ErrorDto, UserDTO>> GetByIdAsync(Guid id, string apiUrl)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        return ToDto<UserDTO>(user, apiUrl);
    }

    public async Task<Either<ErrorDto, UserDTO>> UpdateUserAsync(Guid id, UpdateUserDTO dto, string apiUrl)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        _mapper.Map(dto, user);

        var userUpdated = await _userManager.UpdateAsync(user);
        if (!userUpdated.Succeeded)
        {
            _logger.LogIdentityError(user, userUpdated);
            return new IdentityErrorDTO("Unable to update user");
        }

        _logger.LogInformation("User updated: {0}", user.Id);

        return ToDto<UserDTO>(user, apiUrl);
    }

    public async Task<Option<ErrorDto>> UploadAvatarAsync(Guid userId, IFormFile stream)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        if (!_appData.AllowedImages.ContainsKey(stream.ContentType))
            return new IncorrectParametersErrorDTO("This type of files is not allowed");

        if (user.Avatar != null && File.Exists(user.Avatar))
            File.Delete(user.Avatar);

        var directory = Path.Combine(_appData.UserAvatarDirectoryPath, user.Id.ToString("N"));

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        var localAvatarPath = Path.Combine(directory, $"{_appData.AvatarFileName}{_appData.AllowedImages[stream.ContentType]}");
        
        user.Avatar = Path.Combine("http:\\\\localhost:7243", $"Uploads\\Users\\{user.Id.ToString("N")}\\{_appData.AvatarFileName}{_appData.AllowedImages[stream.ContentType]}");

        await using var outputStream = File.Create(localAvatarPath);
        await using var inputStream = stream.OpenReadStream();
        await inputStream.CopyToAsync(outputStream);

        var userUpdated = await _userManager.UpdateAsync(user);
        if (!userUpdated.Succeeded)
        {
            _logger.LogIdentityError(user, userUpdated);
            return new IdentityErrorDTO("Unable to update user. Please try again later");
        }

        return Option<ErrorDto>.None;
    }

    public async Task<Option<ErrorDto>> DeleteAvatarAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return new NotFoundErrorDTO("User with this id does not exist");

        if (user.Avatar is null)
            return Option<ErrorDto>.None;

        if (File.Exists(user.Avatar))
            File.Delete(user.Avatar);

        user.Avatar = null;
        var userUpdated = await _userManager.UpdateAsync(user);
        if (!userUpdated.Succeeded)
        {
            _logger.LogIdentityError(user, userUpdated);
            return new IdentityErrorDTO("Unable to update user. Please try again later");
        }

        return Option<ErrorDto>.None;
    }


    private T ToDto<T>(User user, string apiUrl)
    {
        user.Avatar = (user.Avatar ?? _appData.DefaultUserAvatarPath).PathToUrl(apiUrl);
        return _mapper.Map<T>(user);
    }
}