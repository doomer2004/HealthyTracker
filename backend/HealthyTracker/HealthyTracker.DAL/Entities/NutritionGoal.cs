using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class NutritionGoal : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid NutritionId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(NutritionId))]
    public Nutrition Nutrition { get; set; }
}