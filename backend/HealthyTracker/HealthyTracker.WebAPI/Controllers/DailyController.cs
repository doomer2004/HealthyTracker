using System.Security.Claims;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using HealthyTracker.DAL.Entities;
using HealthyTracker.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Route("api/daily")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DailyController : ControllerBase
{
    private readonly IDailyService _dailyService;
    private readonly UserManager<User> _userManager;
    public DailyController(IDailyService dailyService, UserManager<User> userManager)
    {
        _dailyService = dailyService;
        _userManager = userManager;
    }
    
    [HttpGet("check-daily")]

    public async Task<IActionResult> CheckDaily([FromQuery] DateTime date)
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());
        
        var result = await _dailyService.CheckDailyAsync(u.Id, date);

       return Ok(result);
    }

    [HttpPost("daily")]
    public async Task<IActionResult> UpdateAsync(DateTime date)
    {
        var u = await _userManager.FindByIdAsync(HttpContext.GetUserId().ToString());

        try
        {
            var result = await _dailyService.GetOrCreateAsync(u.Id, date);
            /*await _dailyService.UpdateAsync(u.Id, DateTime.Now);*/
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

    }

}