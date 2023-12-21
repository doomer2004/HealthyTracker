using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories;

public class CaloriesConsumedRepository : RepositoryBase<CaloriesConsumed, int>
{
    protected CaloriesConsumedRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}