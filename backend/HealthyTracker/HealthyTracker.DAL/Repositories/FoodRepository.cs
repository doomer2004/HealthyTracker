using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories;

public class FoodRepository : RepositoryBase<Food, int>, IFoodRepository
{
    protected FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Food>> GetAll()
    {
        var query = Table.AsQueryable();
        return await query.ToListAsync();
    }
}