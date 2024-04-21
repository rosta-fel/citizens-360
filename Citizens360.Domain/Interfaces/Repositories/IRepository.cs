using Citizens360.Domain.Interfaces.Entities;

namespace Citizens360.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    void Create(TEntity entity);
    IQueryable<TEntity> Get();
    TEntity? Get(int id);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}