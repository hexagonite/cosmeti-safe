using CosmetiSafe.Domain;
using Microsoft.EntityFrameworkCore;

namespace CosmetiSafe.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbContext _dbContext;
    
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    IQueryable<TEntity> IRepository<TEntity>.GetAll()
    {
        return _dbContext.Set<TEntity>();
    }
    
    IQueryable<TEntity> IRepository<TEntity>.GetAllAsNoTracking()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}