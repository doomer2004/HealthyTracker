using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;

namespace HealthyTracker.DAL.Repositories;

public class NutritionRepository : RepositoryBase<Nutrition, int>, INutritionRepository
{
    public NutritionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}