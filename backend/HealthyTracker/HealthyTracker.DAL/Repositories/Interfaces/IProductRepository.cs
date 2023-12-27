using HealthyTracker.DAL.Entities;

namespace HealthyTracker.DAL.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAll();
}