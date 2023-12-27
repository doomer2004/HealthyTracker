namespace HealthyTracker.Common.Models.DTOs.Product;

public class ProductActualDTO
{
    public int Volume { get; set; }
    public Guid ProductId { get; set; }
    public Guid MealId { get; set; }
}