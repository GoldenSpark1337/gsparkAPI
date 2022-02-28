using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class TrackService: ITrackRepository
{
    private readonly MarketPlaceContext _context;

    public TrackService(MarketPlaceContext context)
    {
        _context = context;
    }
    
    public async Task<Track> GetTrackAsync(int id)
    {
        var entity = await _context.Tracks
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == id);
        return entity ?? throw new NotFoundException(nameof(entity), id);
    }

    public async Task<IReadOnlyList<Track>> GetAllTracksAsync()
    {
        return await _context.Tracks
            .Include(t => t.User)
            .ToListAsync();
    }

    public async Task<int> AddTrack(Track track)
    {
        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();
        return track.Id;
    }

    public async Task DeleteTrack(int id)
    {
        var entity = await _context.Tracks.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Tracks.Remove(entity);
        await _context.SaveChangesAsync();
    }
}