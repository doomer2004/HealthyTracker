using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;

[ApiController]
[Route("api/nutrition-goal")]
public class INutritionGoalController : ControllerBase
{
    private readonly INutritionGoalService _nutritionGoalService;

    public INutritionGoalController(INutritionGoalService nutritionGoalService)
    {
        _nutritionGoalService = nutritionGoalService;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateGoal(Guid userId, NutritionGoalDTO dto)
    {
        await _nutritionGoalService.SaveAsync(userId, dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetGoal(Guid userId)
    {
        var result = await _nutritionGoalService.GetAsync(userId);
        return result.ToActionResult();
    }
}