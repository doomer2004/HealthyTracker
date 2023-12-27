using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.User;

namespace HealthyTracker.Common.Models.DTOs.Calories;

public class NutritionGoalDTO
{
    public Guid UserId { get; set; } = Guid.Empty;
    public NutritionDTO Nutrition { get; set; } = null!;
}