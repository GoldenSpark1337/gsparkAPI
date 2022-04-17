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
    
    public TrackWithUsersSpecification(TrackSpecParams trackParams)
        : base(t =>
            (string.IsNullOrEmpty(trackParams.Search) || (t.Title.ToLower().Contains(trackParams.Search))) &&
            (!trackParams.GenreId.HasValue || t.GenreId == trackParams.GenreId) &&
            (t.Price > (decimal)trackParams.minPrice && t.Price < (decimal)trackParams.maxPrice) &&
            (!trackParams.KeyId.HasValue || t.TrackKey_Id == trackParams.KeyId) &&
            (Convert.ToInt16(t.Bpm) > (int)trackParams.minBpm && Convert.ToInt16(t.Bpm) < (int)trackParams.maxBpm)
        )
    {
        AddInclude(track => track.User);
        AddInclude(track => track.Genre);
        AddInclude(track => track.Subgenre);
        AddInclude(track => track.Key);
        AddInclude(track => track.Comments);
        AddOrderByDescending(track => track.ReleaseDate);

        // if (!string.IsNullOrEmpty(trackParams.SortBy))
        // {
        //     switch (trackParams.SortBy)
        //     {
        //         case "oldest":
        //             AddOrderBy(t => t.ReleaseDate);
        //             break;
        //         case "newest":
        //             AddOrderByDescending(t => t.ReleaseDate);
        //             break;
        //         default:
        //             AddOrderByDescending(t => t.ReleaseDate);
        //             break;
        //     }
        // }
        // else
        // {
        //     AddOrderByDescending(t => t.ReleaseDate);
        // }
    }
}