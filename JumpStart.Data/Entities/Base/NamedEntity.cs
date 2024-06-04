using JumpStart.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpStart.Data.Entities.Base;

public abstract class NamedEntity : Entity, INamedEntity
{
    [Column(Order = 1)]
    public string Name { get; set; } = string.Empty;
}
