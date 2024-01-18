using System.Security.Claims;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Route("api/daily")]
public class DailyController : ControllerBase
{
    private readonly IDailyService _dailyService;
    
    public DailyController(IDailyService dailyService)
    {
        _dailyService = dailyService;
    }
    
    [HttpGet("check-daily")]
    [Authorize]
    public async Task<IActionResult> CheckDaily()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value == null) return BadRequest();
        var userId = Guid.Parse(value);
        
        var result = await _dailyService.CheckDailyAsync(userId);

        if (result)
        {
            return Ok();
        }

        return BadRequest();
    }
    
}