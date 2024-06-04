namespace JumpStart.Api.Filtering;

public class FilterCriteria
{
    public string PropertyName { get; set; }
    public FilterOperator Operator { get; set; }
    public string Value { get; set; }
    public List<string> Values { get; set; } = new();
    public FilterLogic Logic { get; set; }
}
