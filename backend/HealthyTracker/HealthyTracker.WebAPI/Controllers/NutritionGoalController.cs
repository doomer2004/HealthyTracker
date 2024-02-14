using System.Security.Claims;
using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/nutrition-goal")]
public class NutritionGoalController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly INutritionGoalService _nutritionGoalService;

    public NutritionGoalController(INutritionGoalService nutritionGoalService, UserManager<User> userManager)
    {
        _nutritionGoalService = nutritionGoalService;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateGoal(NutritionGoalDTO dto)
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());
        
        await _nutritionGoalService.SaveAsync(u.Id, dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetGoal()
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());
        
        var result = await _nutritionGoalService.GetAsync(u.Id);
        return result.ToActionResult();
    }
}