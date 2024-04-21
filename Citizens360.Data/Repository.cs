using Citizens360.Domain.Interfaces.Entities;
using Citizens360.Domain.Interfaces.Repositories;

namespace Citizens360.Data;

public class Repository<TEntity>(DataContext context) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DataContext _context = context;

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }
}