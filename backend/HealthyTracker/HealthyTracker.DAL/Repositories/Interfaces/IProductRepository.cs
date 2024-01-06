using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories;

public interface IProductRepository : IRepository<Product, Guid>
{ 
    public Task<IEnumerable<Product>> GetAll();
}