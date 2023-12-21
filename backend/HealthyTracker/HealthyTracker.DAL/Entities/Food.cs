using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class Food : BaseEntity<Guid>
{
    public string ProductName { get; set; }
    public List<Meal> Meals { get; set; }
    public Guid NutritionId { get; set; }
    
    
    [ForeignKey(nameof(NutritionId))]
    public Nutrition Nutrition { get; set; }
}