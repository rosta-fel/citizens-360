using System.Linq;
using Citizens360.Domain.Interfaces.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbContext _context;

    protected Repository(DbContext context)
    {
        _context = context;
    }

    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public IQueryable<TEntity> Get()
    {
        return _context.Set<TEntity>();
    }

    public TEntity? Get(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}