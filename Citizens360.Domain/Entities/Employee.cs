using Citizens360.Domain.Interfaces.Entities;

namespace Citizens360.Domain.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Username { get; set; }
    public string? Password { get; set; }
}