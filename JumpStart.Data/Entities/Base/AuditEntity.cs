using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpStart.Data.Entities.Base;

public abstract class AuditEntity : Entity, IAuditableEntity
{
    public IdentityUser CreatedBy { get; set; } = null!;
    [Column(Order = 100)]
    public string CreatedById { get; set; }
    [Column(Order = 101)]
    public DateTime CreatedOn { get; set; }

    public IdentityUser? UpdatedBy { get; set; }
    [Column(Order = 102)]
    public string? UpdatedById { get; set; }
    [Column(Order = 103)]
    public DateTime? UpdatedOn { get; set; }

    public IdentityUser? DeletedBy { get; set; }
    [Column(Order = 104)]
    public string? DeletedById { get; set; }
    [Column(Order = 105)]
    public DateTime? DeletedOn { get; set; }
}
