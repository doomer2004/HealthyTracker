using System.Security.Claims;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.BLL.Services.UserServices.Interfaces;
using HealthyTracker.Common.Models.DTOs.User;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private UserManager<User> _userManager;
    public UserController(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [HttpPost("upload-avatar")]
    public async Task<IActionResult> UploadAvatar([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Invalid file.");
        }

        var userId = HttpContext.GetUserId().ToString();
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        try
        {
            var result = await _userService.UploadAvatarAsync(user.Id, file);
            return result.ToActionResult();
        }
        catch (Exception e)
        {
            // Consider logging the exception details here
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpDelete("delete-avatar")]
    public async Task<IActionResult> DeleteAvatar()
    {
        /*var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);*/
        
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());

        try
        {
            var result = await _userService.DeleteAvatarAsync(u.Id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser(UpdateUserDTO dto, string address)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);

        try
        {
            await _userService.UpdateUserAsync(userId, dto, address);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}