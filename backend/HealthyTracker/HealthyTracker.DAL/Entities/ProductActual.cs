using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;

namespace HealthyTracker.DAL.Entities;

public class ProductActual : BaseEntity<Guid>
{
    public int Volume { get; set; }
    public Guid ProductId { get; set; }
    public Guid MealId { get; set; }
    
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
    [ForeignKey(nameof(MealId))]
    public Meal Meal { get; set; }
}