using Citizens360.Domain.Entities;

namespace Citizens360.Domain.Interfaces.Repositories;

public interface IEmployeeRepository : IDisposable
{
    void Create(Employee employee);
    IQueryable<Employee> Get();
    Employee? Get(int id);
    void Update(Employee employee);
    void Delete(int id);
    void SaveChanges();
}