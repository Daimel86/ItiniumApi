using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class ClientModelPost
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string ClientName { get; set; } = null!;
 
    public static implicit operator ClientsEntity(ClientModelPost entity) =>
        new()
        {
            ClientName = entity.ClientName,
            Id = entity.Id
        };
}
