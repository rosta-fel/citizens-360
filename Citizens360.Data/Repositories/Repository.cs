using Citizens360.Domain.Interfaces.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class Repository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly DbContext Context = context;
    
    public void Create(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public IQueryable<TEntity> Get()
    {
        return Context.Set<TEntity>();
    }

    public TEntity? Get(int id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}