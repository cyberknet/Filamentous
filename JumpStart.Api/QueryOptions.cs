using JumpStart.Api.Filtering;

namespace JumpStart.Api;

public class QueryOptions
{
    public List<FilterCriteria> Filters { get; set; } = new();
    public SortedDictionary<string, bool> Sort { get; set; } = new SortedDictionary<string, bool>();
    public string SortOrder { get; set; } = string.Empty;
    public int PageSize { get; set; }
    public int Page { get; set; }
}
