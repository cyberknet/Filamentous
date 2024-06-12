using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Entities;
public class ProductLine : NamedAuditEntity, IAuditableEntity
{
    [Column(Order = 2)]
    public Polymer Polymer { get; set; } = null!;
    public Guid PolymerTypeId { get; set; }
}
