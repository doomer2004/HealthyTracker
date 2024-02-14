using System.Security.Claims;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/meal")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;
    private readonly UserManager<User> _userManager;

    public MealController(IMealService mealService, UserManager<User> userManager)
    {
        _mealService = mealService;
        _userManager = userManager;
    }

    [HttpGet("user-meal")]
    public async Task<IActionResult> GetUserMeal(DateTime date)
    {
        
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());

        try
        {
            var result = await _mealService.GetUserMealAsync(u.Id, date);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        /*var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value != null)
        {
            var realUserId = Guid.Parse(value);
            var result = await _mealService.GetUserMealAsync(realUserId);
            return Ok();
        }

        return Unauthorized();*/
    }

    [HttpGet("all-products")]
    public async Task<IActionResult> GetAllProducts(DateTime date, Guid mealId)
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());
        try
        {
            var result = await _mealService.GetAllProductsAsync(u.Id, date, mealId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
        return BadRequest();
    }
    
    [HttpGet("nutrition")]
    public async Task<IActionResult> GetNutrition(Guid mealId)
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());
        try
        {
            var result = await _mealService.GetNutritionAsync(u.Id, mealId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    
}