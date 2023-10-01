namespace CosmetiSafe.Data;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllAsNoTracking();
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Save();
    Task SaveAsync();
}