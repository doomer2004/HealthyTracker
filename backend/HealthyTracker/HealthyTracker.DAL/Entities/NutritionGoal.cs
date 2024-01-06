using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class NutritionGoal : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}