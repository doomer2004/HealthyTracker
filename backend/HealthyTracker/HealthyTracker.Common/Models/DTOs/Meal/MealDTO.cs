using HealthyTracker.Common.Models.DTOs.Product;

namespace HealthyTracker.Common.Models.DTOs.Meal;

public class MealDTO
{
    public string MealType { get; set; } = string.Empty;
    public List<ProductDTO> Foods { get; set; }
}