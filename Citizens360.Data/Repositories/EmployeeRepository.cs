using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class EmployeeRepository(DbContext context) : Repository<Employee>(context), IEmployeeRepository
{
    private Citizens360Context? Citizens360Context => Context as Citizens360Context;

    public IQueryable<Employee> SortEmployeesByLastName()
    {
        if (Citizens360Context is null)
            throw new InvalidOperationException($"The context is not of type {nameof(Citizens360Context)}.");
        
        return Citizens360Context.Employees
            .OrderBy(e => e.LastName);
    }
}