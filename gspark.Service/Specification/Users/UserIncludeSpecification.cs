using gspark.Domain.Models;

namespace gspark.Service.Specification;

public class UserIncludeSpecification : BaseSpecification<User>
{
    public UserIncludeSpecification()
    {
        AddInclude(u => u.RecordLabel);
        AddInclude(u => u.Playlists);
        AddInclude("Products.ProductType");
    }

    public UserIncludeSpecification(UserSpecParams userParams) 
        : base(u => 
            (string.IsNullOrEmpty(userParams.Search) || (u.UserName.ToLower().Contains(userParams.Search))))
    {
        AddInclude(u => u.RecordLabel);
        AddInclude(u => u.Playlists);
        AddInclude("Products.ProductType");
        ApplyPaging(userParams.PageSize * (userParams.PageIndex - 1), userParams.PageSize);
    }
}