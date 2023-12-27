using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;

namespace HealthyTracker.DAL.Repositories;

public class DailyRepository : RepositoryBase<Daily, int>, IDailyRepository
{
    protected DailyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}