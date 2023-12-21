using HealthyTracker.DAL.Entities;

namespace HealthyTracker.DAL.Repositories;

public interface IFoodRepository
{
    public Task<IEnumerable<Food>> GetAll();
}