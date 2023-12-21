using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories.Base;

public interface IRepository<TEntity, in TKey>
    where TEntity : class
    where TKey : IEquatable<TKey>
{
    DbSet<TEntity> Table  { get; }
    
    Task<TEntity?> Get(Guid id, bool persist = true);
    Task<bool> Insert(TEntity entity, bool persist = true);
    Task<bool> Update(TEntity entity, bool persist = true);
    Task<bool> Delete(TEntity entity, bool persist = true);
    
    int SaveChanges();
    Task<int> SaveChangesAsync();   
}