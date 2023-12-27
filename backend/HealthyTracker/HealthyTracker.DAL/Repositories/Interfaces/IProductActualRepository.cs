using HealthyTracker.DAL.Entities;

namespace HealthyTracker.DAL.Repositories.Interfaces;

public interface IProductActualRepository
{
    public Task<List<ProductActual>> GetAll();
}