using System.ComponentModel.DataAnnotations;
using Citizens360.Domain.Interfaces.Entities;

namespace Citizens360.Domain.Entities;

public class Employee : IEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(32)]
    public string? FirstName { get; set; }
    
    [Required]
    [MaxLength(32)]
    public string? LastName { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string? Username { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string? Password { get; set; }
}