using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Data.Rest;
public class PagedResponse<TEntity> where TEntity : Entity
{
    public IQueryable<TEntity> Data { get; set; } = new List<TEntity>().AsQueryable();
    public int Count { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
}
