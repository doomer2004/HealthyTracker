using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;

namespace HealthyTracker.DAL.Repositories;

public class NutritionGoalRepository : RepositoryBase<NutritionGoal, int>, INutritionGoalRepository
{
    public NutritionGoalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}