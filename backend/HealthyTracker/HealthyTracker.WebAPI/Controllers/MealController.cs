using HealthyTracker.BLL.Services.MealService.Interfaces;
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
    public async Task<IActionResult> GetAllProducts(Guid userId, DateTime date, Guid mealId)
    {
        try
        {
            var result = await _mealService.GetAllProductsAsync(userId, date, mealId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("nutrition")]
    public async Task<IActionResult> GetNutrition(Guid userId, Guid mealId)
    {
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
    public async Task<IActionResult> AddMeal(Guid userId, Guid dailyId)
    {
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