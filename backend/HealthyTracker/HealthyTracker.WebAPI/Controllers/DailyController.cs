using HealthyTracker.BLL.Services.DailyService.Interfaces;
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
    public async Task<IActionResult> CheckDaily(Guid userId)
    {
        var result = await _dailyService.CheckDailyAsync(userId);

        if (result == true)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
    
}