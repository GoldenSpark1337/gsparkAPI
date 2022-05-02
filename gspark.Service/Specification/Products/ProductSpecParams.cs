namespace gspark.Service.Specification;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 6;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    private string _category;
    public string? Category { get { return _category; } set => _category= value.ToLower(); }
    public string? SortBy { get; set; }
    public int? GenreId { get; set; }
    public double minPrice { get; set; } = 0;
    public double maxPrice { get; set; } = 999.9;
    public int? KeyId { get; set; }
    public double minBpm { get; set; } = 0;
    public double maxBpm { get; set; } = 250;
    public bool IsDraft { get; set; } = false;
    public string? Tags { get; set; }
    private string _search;

    public string? Search
    {
        get => _search; 
        set => _search = value.ToLower();
    }
}