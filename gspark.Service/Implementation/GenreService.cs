using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class GenreService : IGenreRepository
{
    private readonly MarketPlaceContext _context;

    public GenreService(MarketPlaceContext context)
    {
        _context = context;
    }
    
    public async Task<Genre> GetGenreAsync(int id)
    {
        var entity = await _context.Genres
            // .Include(g => g.Subgenres)
            .Include(g => g.Tracks)
            .FirstOrDefaultAsync(t => t.Id == id);
        return entity ?? throw new NotFoundException(nameof(entity), id);
    }

    public async Task<IReadOnlyList<Genre>> GetAllGenresAsync()
    {
        return await _context.Genres
            .Include(g => g.Subgenres)
            .Include(g => g.Tracks)
            .ToListAsync();
    }

    public async Task<int> AddGenreAsync(Genre track)
    {
        await _context.Genres.AddAsync(track);
        await _context.SaveChangesAsync();
        return track.Id;
    }

    public async Task DeleteGenre(int id)
    {
        var entity = await _context.Genres.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Genres.Remove(entity);
        await _context.SaveChangesAsync();
    }
}