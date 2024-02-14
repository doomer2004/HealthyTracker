namespace HealthyTracker.Common.Models.Request;

public class AddProductRequest
{
    public string Name { get; set; }
    public int Volume { get; set; }
    public Guid MealId { get; set; }
}