using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;

namespace HealthyTracker.DAL.Repositories;

public class MealRepository : RepositoryBase<Meal, int>, IMealRepository
{
    public MealRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}