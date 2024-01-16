using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyTracker.DAL.Entities;

public class Meal : BaseEntity<Guid>
{
    public string Type { get; set; } = null!;
    public Guid DailyId { get; set; }
    public List<Product> Products { get; set; }
    
    [ForeignKey(nameof(DailyId))]
    public Daily Daily { get; set; }
}
