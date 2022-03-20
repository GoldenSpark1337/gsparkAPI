﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Dtos.UserDtos;
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
            // .Include(u => u.Tracks)
            // .Include(u => u.Kits)
            // .Include(u => u.Services)
            .Include(u => u.RecordLabel)
            .Include(u => u.Playlists)
            .Include(u => u.Orders)
            .ToListAsync();
    }
    
    // public async Task<DtoReturnMusician> GetUserByIdAsync(int id)
    // {
    //     return await _context.Users
    //         .Where(u => u.Id == id)
    //         .ProjectTo<DtoReturnMusician>(_mapper.ConfigurationProvider)
    //         .SingleOrDefaultAsync() ?? throw new NotFoundException(nameof(User), id);
    // }

    public async Task<DtoReturnMusician> GetUserByName(string username)
    {
        return await _context.Users
            .Where(u => u.UserName == username)
            .ProjectTo<DtoReturnMusician>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync() ?? throw new NotFoundException(username);
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteUser(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null) throw new NotFoundException(nameof(entity), entity.Id);
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }
}