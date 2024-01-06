using HealthyTracker.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Repositories.Base;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : IEquatable<TKey>

{
    public DbSet<TEntity> Table  { get; }
    private ApplicationDbContext DbContext { get; }

    protected RepositoryBase(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        Table  = DbContext.Set<TEntity>();
    }
    

    public virtual async Task<TEntity?> Get(Guid id, bool persist = true)
    {
        var entity = await Table.FindAsync(id);
        return entity;
    }

    public virtual async Task<bool> Insert(TEntity entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist && await SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Update(TEntity entity, bool persist = true)
    {
        Table.Update(entity);
        return persist && await SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Delete(TEntity entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist && await SaveChangesAsync() > 0;
    }

    public virtual int SaveChanges()
    {
        try
        {
            return DbContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred updating the database", e);
        }
    }
    
    public virtual async Task<int> SaveChangesAsync()
    {
        try
        {
            return await DbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred updating the database");
        }
    }

    
}