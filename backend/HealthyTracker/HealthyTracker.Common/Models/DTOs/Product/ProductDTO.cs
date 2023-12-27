using HealthyTracker.Common.Models.DTOs.Nutrition;

namespace HealthyTracker.Common.Models.DTOs.Product;

public class ProductDTO 
{
    public string ProductName { get; set; } = string.Empty;
    public NutritionDTO Nutrition { get; set; } = null!;
    public int Volume { get; set; } 
}