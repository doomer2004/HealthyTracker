using HealthyTracker.Common.Models.DTOs.Calories;

namespace HealthyTracker.BLL.Services.DailyService.Interfaces;

public interface IDailyService
{
    Task<bool> CheckDailyAsync(Guid userId, DateTime date);
    
    /*Task UpdateAsync(Guid userId, DateTime date);*/
    Task<DailyDTO> GetOrCreateAsync(Guid uId, DateTime date);
}