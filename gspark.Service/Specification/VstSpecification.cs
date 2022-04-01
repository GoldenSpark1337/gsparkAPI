using gspark.Domain.Models;

namespace gspark.Service.Specification;

public class VstSpecification : BaseSpecification<Vst>
{
    public VstSpecification()
    {
        AddInclude(v => v.User);
        AddInclude(v => v.ProductType);
    }

    public VstSpecification(ProductSpecParams vstParams)
        : base(v =>
            (string.IsNullOrEmpty(vstParams.Category) || v.ProductType.Name.ToLower() == vstParams.Category.ToLower()) &&
               (string.IsNullOrEmpty(vstParams.Search) || (v.Title.ToLower().Contains(vstParams.Search))) &&
               (v.Price > (decimal)vstParams.minPrice && v.Price < (decimal)vstParams.maxPrice))
    {
        AddInclude(v => v.User);
        AddInclude(v => v.ProductType);
        
        if (!string.IsNullOrEmpty(vstParams.SortBy))
        { 
            switch (vstParams.SortBy)
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