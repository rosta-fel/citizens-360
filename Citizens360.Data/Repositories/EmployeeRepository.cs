using System;
using System.Linq;
using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private Citizens360DbContext? Citizens360DbContext { get; }

    public EmployeeRepository(DbContext context) : base(context)
    {
        Citizens360DbContext = context as Citizens360DbContext;
    }
    
    public IQueryable<Employee> SortEmployeesByLastName()
    {
        if (Citizens360DbContext is null)
            throw new InvalidOperationException($"The context is not of type {typeof(Citizens360DbContext)}.");
        
        return Citizens360DbContext.Employees
            .OrderBy(e => e.LastName);
    }
}