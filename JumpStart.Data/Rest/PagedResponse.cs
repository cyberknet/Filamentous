using JumpStart.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Data.Rest;
public class PagedResponse<TEntity> where TEntity : Entity
{
    public TEntity[] Data { get; set; }
    public int Count { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }

    public PagedResponse()
    {
        Data = [];
    }
    public PagedResponse(IEnumerable<TEntity> data, int count, int limit, int offset)
    {
        if (data is TEntity[] arrayData)
            Data = arrayData;
        else
            Data = data.ToArray();

        Count = count;
        Limit = limit;
        Offset = offset;
    }
}
