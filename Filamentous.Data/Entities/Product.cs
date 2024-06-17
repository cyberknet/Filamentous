using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Entities;
public class Product : NamedAuditEntity, IAuditableEntity
{
    [Column(Order = 2)]
    public ProductLine ProductLine { get; set; } = null!;
    


    [Column(Order = 10)]
    public string? SKU { get; set; }
    [Column(Order = 11)]
    public string? UPC { get; set; }
    [Column(Order = 12)]
    public Uri? ProductUrl { get; set; }
    [Column(Order = 13)]
    public Uri? FilamentXyzUrl { get; set; }
    

    
    [Column(Order = 20)]
    public int ProductWeight { get; set; }
    [Column(Order = 21)]
    public int SpoolWeight { get; set; }
    

    [Column(Order = 30)]
    public string? ColorCode { get; set; }
    [Column(Order = 31)]
    public bool IsGradient { get; set; }
    [Column(Order =32)]
    public int? GradientCycleLength { get; set; }


    [Column(Order =40)]
    [Precision(14,2)]
    public decimal Price { get; set; }
    
    [Column(Order =50)]
    public bool? Discontinued { get; set; }
}
