using gspark.Domain.Models;

namespace gspark.Service.Specification;

public class ProductWithCountSpecification : BaseSpecification<Product>
{
    public ProductWithCountSpecification(ProductSpecParams productParams)
        : base(p =>
            (string.IsNullOrEmpty(productParams.Category) || p.ProductType.Name.ToLower() == productParams.Category.ToLower()) &&
            (string.IsNullOrEmpty(productParams.Search) || (p.Title.ToLower().Contains(productParams.Search))) &&
            (p.Price > (decimal)productParams.minPrice && p.Price < (decimal)productParams.maxPrice))
    {
        
    }
}