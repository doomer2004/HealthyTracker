using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories;

public class CalorieGoalRepository : RepositoryBase<CalorieGoal, int>
{
    protected CalorieGoalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}