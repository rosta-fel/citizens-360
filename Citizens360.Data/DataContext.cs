using Citizens360.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
}