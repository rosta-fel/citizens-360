using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;

namespace Citizens360.Application.Services;

public class EmployeeService(IRepository<Employee> repository) : IEmployeeService
{
    private readonly IRepository<Employee> _repository = repository;

    public Employee? Get(int id)
    {
        return _repository.GetAll().SingleOrDefault(e => e.Id == id);
    }

    public IEnumerable<Employee> Get()
    {
        return _repository.GetAll().ToList();
    }

    public void Create(Employee employee)
    {
        _repository.Create(employee);
    }

    public void Delete(int id)
    {
        Employee employeeToDelete = Get(id) ?? throw new Exception("Employee not found!");
        _repository.Delete(employeeToDelete);
    }
}