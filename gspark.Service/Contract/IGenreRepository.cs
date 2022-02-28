using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface IGenreRepository
{
    Task<Genre> GetGenreAsync(int id);
    Task<IReadOnlyList<Genre>> GetAllGenresAsync();
    Task<int> AddGenreAsync(Genre track);
    Task DeleteGenre(int id);
}