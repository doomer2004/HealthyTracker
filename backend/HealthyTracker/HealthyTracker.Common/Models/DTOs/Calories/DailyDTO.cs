using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.User;

namespace HealthyTracker.Common.Models.DTOs.Calories;

public class DailyDTO
{
    public DateTime Date { get; set; }
    public NutritionDTO Nutrition { get; set; }
    public UserDTO User { get; set; }
}