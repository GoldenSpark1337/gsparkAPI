using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Features.Users.Queries.GetUser;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class UserService: IUserService
{
    private readonly MarketPlaceContext _context;

    public UserService(MarketPlaceContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserByIdAsync(int id)
    {
        var entity = await _context.Users
            .Include(u => u.Tracks)
            .Include(u => u.Kits)
            .Include(u => u.Services)
            .Include(u => u.RecordLabel)
            .Include(u => u.Playlists)
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Id == id);
        return entity ?? throw new NotFoundException(nameof(entity), id);
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Tracks)
            .Include(u => u.Kits)
            .Include(u => u.Services)
            .Include(u => u.RecordLabel)
            .Include(u => u.Playlists)
            .Include(u => u.Orders)
            .ToListAsync();
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteUser(int id)
    {
        var entity = await _context.Tracks.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Tracks.Remove(entity);
        await _context.SaveChangesAsync();
    }
}