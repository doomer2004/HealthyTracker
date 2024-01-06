namespace HealthyTracker.BLL.Services.DailyService.Interfaces;

public interface IDailyService
{
    Task<bool> CheckDailyAsync(Guid userId);
}