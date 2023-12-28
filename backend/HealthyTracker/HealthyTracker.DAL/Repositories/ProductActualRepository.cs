using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories;

public class ProductActualRepository : RepositoryBase<ProductActual, int>, IProductActualRepository
{
    public ProductActualRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<ProductActual>> GetAll()
    {
        return await Table.ToListAsync();
    }
}