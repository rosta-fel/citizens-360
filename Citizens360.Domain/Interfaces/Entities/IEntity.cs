using System.ComponentModel.DataAnnotations;

namespace Citizens360.Domain.Interfaces.Entities;

public interface IEntity
{
    [Key]
    public int Id { get; set; }
}