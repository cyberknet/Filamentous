using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpStart.Data.Entities.Base;

public class Entity
{
    public Entity()
    {
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 0)]
    public Guid Id { get; set; }

    [Column(Order = 99)]
    [ConcurrencyCheck]
    public Guid ConcurrencyStamp { get; set; }
}
