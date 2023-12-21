using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories;

public class MealRepository : RepositoryBase<Meal, int>
{
    protected MealRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}