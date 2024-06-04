using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Data.Rest;
public class Sort
{
    public string Property { get; set; } = string.Empty;
    public ListSortDirection Direction { get; set; }
}
