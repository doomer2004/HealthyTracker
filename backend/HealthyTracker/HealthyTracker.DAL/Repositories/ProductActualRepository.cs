using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories;

public class ProductActualRepository : RepositoryBase<ProductActual, int>, IProductActualRepository
{
    protected ProductActualRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<ProductActual>> GetAll()
    {
        var query = Table.AsQueryable();
        return await query.ToListAsync();
    }
}