
using HealthyTracker.Common.Models.DTOs.User;

namespace HealthyTracker.Common.Models.DTOs.Calories;

public class NutritionGoalDTO
{
    public Guid UserId { get; set; } = Guid.Empty;
    public float Calories { get; set; }
    public float Proteins { get; set; }
    public float Fat { get; set; }
    public float Carbohydrates { get; set; }
}