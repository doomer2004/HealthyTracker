using HealthyTracker.DAL.Entities;

namespace HealthyTracker.DAL.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAll();
}