using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Entities;
public class Product : NamedEntity
{
    [Column(Order = 2)]
    public Brand Brand { get; set; }
    [Column(Order = 3)]
    public FilamentType FilamentType { get; set; }


    [Column(Order = 10)]
    public string SKU { get; set; }
    [Column(Order = 11)]
    public Uri? ProductUrl { get; set; }
    

    [Column(Order = 20)]
    [MaxLength(7)]
    public string Color { get; set; }
    [Column(Order = 21)]
    [MaxLength(50)]
    public string ColorName { get; set; }
    [Column(Order = 12)]


    public int Weight { get; set; }
    [Column(Order = 30)]
    public int SpoolWeight { get; set; }

    [Column(Order =40)]
    public bool? Discontinued { get; set; }
}
