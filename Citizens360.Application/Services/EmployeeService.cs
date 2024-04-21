using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;

namespace Citizens360.Application.Services;

public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
{
    public Employee? Get(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        return repository.Get(id);
    }

    public IEnumerable<Employee?> Get()
    {
        return repository.Get();
    }

    public void Create(Employee employee)
    {
        repository.Create(employee);
    }

    public void Delete(Employee employee)
    {
        repository.Delete(employee);
    }

    public void Update(Employee employee)
    {
        repository.Update(employee);
    }
}