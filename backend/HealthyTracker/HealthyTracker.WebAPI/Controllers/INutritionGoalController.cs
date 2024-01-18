using System.Security.Claims;
using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;

[ApiController]
[Route("api/nutrition-goal")]
public class NutritionGoalController : ControllerBase
{
    private readonly INutritionGoalService _nutritionGoalService;

    public NutritionGoalController(INutritionGoalService nutritionGoalService)
    {
        _nutritionGoalService = nutritionGoalService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateGoal(NutritionGoalDTO dto)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        await _nutritionGoalService.SaveAsync(userId, dto);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetGoal()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        var result = await _nutritionGoalService.GetAsync(userId);
        return result.ToActionResult();
    }
}