using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class TrackRepository: ITrackRepository
{
    private readonly MarketPlaceContext _context;

    public TrackRepository(MarketPlaceContext context)
    {
        _context = context;
    }

    public async Task<int> AddTrack(Track track)
    {
        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();
        return track.Id;
    }

    public async Task<int> CountPlays(string username)
    {
        return await _context.Tracks
            .Include(t => t.User)
            .Where(t => t.User.UserName == username)
            .SumAsync(t => t.Plays);
    }
    
    public async Task DeleteTrack(int id)
    {
        var entity = await _context.Tracks.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Tracks.Remove(entity);
        await _context.SaveChangesAsync();
    }
}