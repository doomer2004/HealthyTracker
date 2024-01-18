using System.Security.Claims;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Route("api/meal")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpGet("user-meal")]
    public async Task<IActionResult> GetUserMeal(Guid userId)
    {
        var result = await _mealService.GetUserMealAsync(userId);
        return Ok();
    }

    [HttpGet("all-products")]
    [Authorize]
    public async Task<IActionResult> GetAllProducts(DateTime date, Guid mealId)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        try
        {
            var result = await _mealService.GetAllProductsAsync(userId, date, mealId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        return BadRequest();
    }
    
    [HttpGet("nutrition")]
    [Authorize]
    public async Task<IActionResult> GetNutrition(Guid mealId)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        try
        {
            var result = await _mealService.GetNutritionAsync(userId, mealId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpPut("meal")]
    [Authorize]
    public async Task<IActionResult> AddMeal(Guid dailyId)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        try
        {
            await _mealService.AddMealAsync(userId, dailyId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
}