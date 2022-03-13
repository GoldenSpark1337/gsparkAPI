namespace gspark.Service.Specification;

public class ProductSpecParams
{
    private string _category;
    public string? Category { get { return _category; } set => _category= value.ToLower(); }
    public string? SortBy { get; set; }
    public int? GenreId { get; set; }
    public double minPrice { get; set; } = 0;
    public double maxPrice { get; set; } = 999.9;
    public int? KeyId { get; set; }
    public double minBpm { get; set; } = 0;
    public double maxBpm { get; set; } = 250;
    private string _search;

    public string? Search
    {
        get => _search; 
        set => _search = value.ToLower();
    }
}