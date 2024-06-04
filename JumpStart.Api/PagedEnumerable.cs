namespace JumpStart.Api;

public class PagedEnumerable<T>
{
    public int Total { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public IEnumerable<T> Results { get; set; }

    public PagedEnumerable(IQueryable<T> query, int pageSize, int page)
    {
        var skip = 0;
        Total = query.Count();
        if (page > 0 && pageSize > 0)
        {
            skip = (page - 1) * pageSize;
            if (skip <= Total)
                query = query.Skip(skip);
            Page = page;
            PageSize = pageSize;
        }
        if (pageSize > 0)
        {
            if (Total - skip >= 0)
                query = query.Take(pageSize);
        }
        Results = query.AsEnumerable();
    }
}
