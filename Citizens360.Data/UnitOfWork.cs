using System;
using Citizens360.Data.Repositories;
using Citizens360.Domain.Interfaces;
using Citizens360.Domain.Interfaces.Repositories;

namespace Citizens360.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public IEmployeeRepository Employees { get; }

    private readonly Citizens360Context _context;
    private bool _disposed;

    public UnitOfWork(Citizens360Context context)
    {
        _context = context;

        Employees = new EmployeeRepository(_context);
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}