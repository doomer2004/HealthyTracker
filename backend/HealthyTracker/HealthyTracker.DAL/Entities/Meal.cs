using System.ComponentModel.DataAnnotations.Schema;
using HealthyTracker.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyTracker.DAL.Entities;

public class Meal : BaseEntity<Guid>
{
    public Guid DailyId { get; set; }
    
    [ForeignKey(nameof(DailyId))]
    public Daily Daily { get; set; }
}