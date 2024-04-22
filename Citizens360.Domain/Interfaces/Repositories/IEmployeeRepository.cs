using Citizens360.Domain.Entities;

namespace Citizens360.Domain.Interfaces.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Employee? GetEmployeeByUsername(string? username);
}