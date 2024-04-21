using Citizens360.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Citizens360.Data;

public class Citizens360Context(DbContextOptions<Citizens360Context> options) : DbContext(options)
{
    public required DbSet<Employee> Employees { get; set; }
}