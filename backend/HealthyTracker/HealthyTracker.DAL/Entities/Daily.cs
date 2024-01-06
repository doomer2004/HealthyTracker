using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class Daily : BaseEntity<Guid>
{
    public bool NormIsFulfilled { get; set; }
    public DateTime Date { get; set; }
    public List<Meal> Meals { get; set; }
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

}