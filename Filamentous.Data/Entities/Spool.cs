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
public class Spool : AuditEntity, IAuditableEntity
{
    [Column(Order = 2)]
    public Product Product { get; set; } = null!;
    [Column(Order = 3)]
    public string? ManufacturerSerial { get; set; }
    
   
    [Column(Order = 10)]
    public int InitialWeight { get; set; }
    [Column(Order = 11)]
    public int CurrentWeight { get; set; }
    
}
