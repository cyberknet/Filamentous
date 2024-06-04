using Filamentous.Data.Entities;
using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Entities;
public class Brand : NamedAuditEntity, IAuditableEntity
{
    [Column(Order = 2)]
    public Uri? Url { get; set; }
    
    [Column(Order = 10)]
    public Uri? ProductUrlTemplate { get; set; }
    [Column(Order = 11)]
    public Uri? SpoolUrlTemplate { get; set; }
}
