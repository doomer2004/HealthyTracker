using HealthyTracker.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyTracker.DAL.Entities;

public class Meal : BaseEntity<Guid>
{
    public string MealType { get; set; }
    public List<Food> Foods { get; set; }
}