using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class CaloriesConsumed : BaseEntity<Guid>
{
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public Guid NutritionId { get; set; }
    
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    [ForeignKey(nameof(NutritionId))]
    public Nutrition Nutrition { get; set; }
}