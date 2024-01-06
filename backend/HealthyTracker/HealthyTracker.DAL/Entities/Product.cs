using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class Product : BaseEntity<Guid>
{
    public string ProductName { get; set; } = null!;
    public int Volume { get; set; }
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public float Salt { get; set; }
    public float Cellulose { get; set; }
    public float Water { get; set; }
    public float Caffeine { get; set; } 
}