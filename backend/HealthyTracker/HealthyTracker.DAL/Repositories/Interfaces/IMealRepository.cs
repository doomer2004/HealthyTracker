using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories.Base;

namespace HealthyTracker.DAL.Repositories.Interfaces;

public interface IMealRepository : IRepository<Meal, Guid> { }