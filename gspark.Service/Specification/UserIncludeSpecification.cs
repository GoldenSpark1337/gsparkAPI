using gspark.Domain.Models;

namespace gspark.Service.Specification;

public class UserIncludeSpecification : BaseSpecification<User>
{
    public UserIncludeSpecification()
    {
        AddInclude(u => u.RecordLabel);
        AddInclude(u => u.Playlists);
        // AddInclude(u => u.Kits);
        // AddInclude(u => u.Services);
    }

    public UserIncludeSpecification(int id) : base(u => u.Id == id)
    {
        AddInclude(u => u.RecordLabel);
        AddInclude(u => u.Playlists);
        // AddInclude(u => u.Kits);
        // AddInclude(u => u.Services);
    }
}