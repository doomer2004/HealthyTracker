using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories;

public class NutritionRepository : RepositoryBase<Nutrition, int>
{
    protected NutritionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}