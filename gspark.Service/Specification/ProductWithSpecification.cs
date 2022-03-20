using gspark.Domain.Models;
using System.Linq;

namespace gspark.Service.Specification;

public class ProductWithSpecification : BaseSpecification<Product>
{
    public ProductWithSpecification()
    {
        AddInclude(p => p.User);
        AddInclude(p => p.ProductType);
    }

    public ProductWithSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(p => p.User);
        AddInclude(p => p.ProductType);
    }

    public ProductWithSpecification(ProductSpecParams productParams)
        : base(p =>
            (string.IsNullOrEmpty(productParams.Category) || p.ProductType.Name.ToLower() == productParams.Category.ToLower()) &&
            (string.IsNullOrEmpty(productParams.Search) || (p.Title.ToLower().Contains(productParams.Search))) &&
            (p.Price > (decimal)productParams.minPrice && p.Price < (decimal)productParams.maxPrice)
            
            // ((!productParams.KeyId.HasValue && productParams.Category != "Tracks") 
            //  || p.Tracks.TrackKey_Id == productParams.KeyId) &&
            
            // (productParams.Category != "Tracks") 
            //     || (Convert.ToInt16(p.Tracks.Bpm) > (int)productParams.minBpm 
            //         && Convert.ToInt16(p.Tracks.Bpm) < (int)productParams.maxBpm)
        )
    {
        AddInclude(p => p.User);
        AddInclude(p => p.ProductType);
        
        if (!string.IsNullOrEmpty(productParams.SortBy))
        {
            switch (productParams.SortBy)
            {
                case "oldest":
                    AddOrderBy(p => p.ReleaseDate);
                    break;
                case "newest":
                    AddOrderByDescending(p => p.ReleaseDate);
                    break;
                default:
                    AddOrderByDescending(p => p.ReleaseDate);
                    break;
            }
        }
        else
        {
            AddOrderByDescending(p => p.ReleaseDate);
        }
    }
}