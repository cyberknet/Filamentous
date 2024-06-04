using Microsoft.AspNetCore.Identity;

namespace JumpStart.Data.Entities;

public interface IAuditableEntity
{
    Microsoft.AspNetCore.Identity.IdentityUser CreatedBy { get; set; }
    string CreatedById { get; set; }
    DateTime CreatedOn { get; set; }

    IdentityUser? UpdatedBy { get; set; }
    string? UpdatedById { get; set; }
    DateTime? UpdatedOn { get; set; }

    IdentityUser? DeletedBy { get; set; }
    string? DeletedById { get; set; }
    DateTime? DeletedOn { get; set; }
}
