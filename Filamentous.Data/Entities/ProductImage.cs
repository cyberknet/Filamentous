using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Entities;
public class ProductImage : AuditEntity
{
    [Column(Order = 2)]
    public Product Product { get; set; } = null!;
    public Guid ProductId { get; set; }

    [Column(Order = 3)]
    public ImageType ImageType { get; set; } = null!;
    public Guid ImageTypeId { get; set; }

    [Column(Order = 20), Required, MaxLength(1000)]
    public string Filename { get; set; } = null!;
}
