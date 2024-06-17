using Filamentous.Data.Entities;
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
public class ImageType : NamedAuditEntity, IAuditableEntity
{
    [Column(Order = 10)]

    public int SortOrder { get; set; }
}
