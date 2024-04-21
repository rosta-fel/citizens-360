using System;
using System.Linq;
using Citizens360.Domain.Entities;
using Citizens360.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private Citizens360Context? Citizens360Context { get; }

    public EmployeeRepository(DbContext context) : base(context)
    {
        Citizens360Context = context as Citizens360Context;
    }
    
    public IQueryable<Employee> SortEmployeesByLastName()
    {
        if (Citizens360Context is null)
            throw new InvalidOperationException($"The context is not of type {nameof(Citizens360Context)}.");
        
        return Citizens360Context.Employees
            .OrderBy(e => e.LastName);
    }
}