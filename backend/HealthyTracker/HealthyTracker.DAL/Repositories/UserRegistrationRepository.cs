using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;
using HealthyTracker.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories;

public class UserRegistrationRepository : RepositoryBase<UserRegistration, int>, IUserRegistrationRepository
{
    protected UserRegistrationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    
}