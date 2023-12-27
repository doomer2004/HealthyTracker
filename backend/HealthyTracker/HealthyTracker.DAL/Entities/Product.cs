using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class Product : BaseEntity<Guid>
{
    public string ProductName { get; set; } = null!;
    public int Volume { get; set; }
    public Guid NutritionId { get; set; }
    
    [ForeignKey(nameof(NutritionId))]
    public Nutrition Nutrition { get; set; }
}