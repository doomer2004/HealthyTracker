using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Common.Models.DTOs.Error;
using LanguageExt;

namespace HealthyTracker.BLL.Services.NutritionService.Interfaces;

public interface INutritionGoalService
{
    Task<Either<ErrorDTO, NutritionGoalDTO>> GetAsync(Guid userId);
    
    Task SaveAsync(Guid userId, NutritionGoalDTO dto);

}