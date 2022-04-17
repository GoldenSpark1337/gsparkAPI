using AutoMapper;
using AutoMapper.QueryableExtensions;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class UserService: IUserRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public UserService(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyList<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Products).ThenInclude(p => p.ProductType)
            .Include(u => u.RecordLabel)
            .Include(u => u.Playlists)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<DtoReturnProduct>> GetUserProducts(string username)
    {
        return await _context.Products
            .Where(p => p.User.UserName == username && p.IsDraft == false)
            .ProjectTo<DtoReturnProduct>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
    
    public async Task<IReadOnlyList<DtoReturnTrack>> GetUserTracks(string username, bool isDraft)
    {
        var tracks = await _context.Tracks
            .Include(t => t.User)
            .Include(t => t.Genre)
            .Include(t => t.Subgenre)
            .Include(t => t.Key)
            .Where(t => t.User.UserName == username && t.IsDraft == isDraft)
            .ToListAsync();
        return _mapper.Map<IReadOnlyList<DtoReturnTrack>>(tracks);
    }

    // public async Task<IReadOnlyList<DtoReturnVst>> GetUserVsts(string username)
    // {
    // }

    public async Task<User> GetUserByName(string username)
    {
        return await _context.Users
            .Where(u => u.UserName == username)
            .ProjectTo<User>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync() ?? throw new NotFoundException(username);
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public void UpdateUser(User user)
    {
        _context.Users.Attach(user);
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task DeleteUser(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }
}