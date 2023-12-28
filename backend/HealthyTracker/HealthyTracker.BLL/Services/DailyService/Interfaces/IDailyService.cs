namespace HealthyTracker.BLL.Services.DailyService.Interfaces;

public interface IDailyService
{
    Task AddDailyAsync(Guid userId);
    Task<string> CheckDailyAsync(Guid userId);
}