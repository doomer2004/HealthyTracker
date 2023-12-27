using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories;

public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
{
    protected ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var query = Table.AsQueryable();
        return await query.ToListAsync();
    }
}