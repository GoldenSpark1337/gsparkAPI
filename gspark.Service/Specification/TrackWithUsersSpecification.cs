using gspark.Domain.Models;

namespace gspark.Service.Specification;

public class TrackWithUsersSpecification : BaseSpecification<Track>
{
    public TrackWithUsersSpecification()
    {
        AddInclude(track => track.User);
        AddInclude(track => track.Genre);
        AddInclude(track => track.Subgenre);
        AddInclude(track => track.Key);
    }

    public TrackWithUsersSpecification(int id) : base(t => t.Id == id)
    {
        AddInclude(track => track.User);
        AddInclude(track => track.Genre);
        AddInclude(track => track.Subgenre);
        AddInclude(track => track.Key);
        AddInclude(track => track.Comments);
    }
}