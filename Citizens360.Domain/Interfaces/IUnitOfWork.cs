using Citizens360.Domain.Interfaces.Repositories;

namespace Citizens360.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }

    int Commit();
}