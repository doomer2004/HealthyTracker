using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class Nutrition : BaseEntity<Guid>
{
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public float Salt { get; set; }
    public float Cellulose { get; set; }
    public float Water { get; set; }
    public float Caffeine { get; set; } 
}