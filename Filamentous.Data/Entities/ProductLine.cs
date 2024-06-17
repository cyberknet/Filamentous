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
public class ProductLine : NamedAuditEntity, IAuditableEntity
{
    [Column(Order =10), Required]
    public Brand Brand { get; set; }
    public Guid BrandId { get; set; }

    [Column(Order = 10)]
    [Required]
    public Polymer Polymer { get; set; } = null!;
    public Guid PolymerId { get; set; }


    [Column(Order = 20)]
    public bool IsAbrasive { get; set; } = false;
    
    [Column(Order = 21)]
    public int HotEndTemperature { get; set; } = 200;
    
    [Column(Order = 22)]
    public int BedTemperature { get; set; } = 60;
}
