using Citizens360.Domain.Entities;

namespace Citizens360.Application.Services;

public interface IEmployeeService
{
    Employee? Get(int id);
    IEnumerable<Employee?> Get();
    void Create(Employee employee);
    void Delete(int id);
    void Update(Employee employee);
}