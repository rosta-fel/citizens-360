using Citizens360.Domain.Interfaces.Entities;

namespace Citizens360.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> GetAll();
    void Delete(TEntity entity);
    void Create(TEntity entity);
}