using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class EmployeeRepository(DataContext dataContext) : IEmployeeRepository
{
    private bool _disposed;

    public void Create(Employee employee)
    {
        dataContext.Employees.Add(employee);
    }

    public IQueryable<Employee> Get()
    {
        return dataContext.Employees;
    }

    public Employee? Get(int id)
    {
        return dataContext.Employees.Find(id);
    }

    public void Update(Employee employee)
    {
        dataContext.Entry(employee).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        Employee toDelete = Get(id) ?? throw new Exception("Employee not found!");
        dataContext.Employees.Remove(toDelete);
    }

    public void SaveChanges()
    {
        dataContext.SaveChanges();
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                dataContext.Dispose();
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}