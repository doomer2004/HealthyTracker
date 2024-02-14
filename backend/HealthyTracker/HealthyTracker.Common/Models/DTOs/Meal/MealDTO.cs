using HealthyTracker.Common.Models.DTOs.Product;

namespace HealthyTracker.Common.Models.DTOs.Meal;

public class MealDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public List<ProductDTO> Products { get; set; }
}