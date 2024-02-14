
using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.Common.Models.DTOs.User;

namespace HealthyTracker.Common.Models.DTOs.Calories;

public class DailyDTO
{
    public DateTime Date { get; set; }
    public bool NormIsFulfilled { get; set; }
    // public UserDTO User { get; set; }
    public List<MealDTO> Meals { get; set; }
}