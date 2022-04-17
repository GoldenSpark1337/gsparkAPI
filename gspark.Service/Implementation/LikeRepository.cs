using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Dtos.LikeDtos;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class LikeRepository : ILikesRepository
{
    private readonly MarketPlaceContext _context;

    public LikeRepository(MarketPlaceContext context)
    {
        _context = context;
    }

    public async Task<UserProductLike> GetUserLike(int userId, int productId)
    {
        return await _context.Likes.FindAsync(userId, productId);
    }

    /// <summary>
    /// List of products that this user has liked
    /// </summary>
    public async Task<User> GetUserWithLikes(int userId)
    {
        return await _context.Users
            .Include(x => x.Likes)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<IEnumerable<DtoLike>> GetProductLikes(string predicate, int productId)
    {
        var products = _context.Products.AsQueryable();
        var users = _context.Users.AsQueryable();
        var likes = _context.Likes.AsQueryable();

        if (predicate == "liked")
        {
            // current user favourite products
            likes = likes.Where(like => like.UserId == productId); // param change to userId?
            products = likes.Select(like => like.Product);
            return await products.Select(p => new DtoLike
            {
                Id = p.Id,
                Username = p.Title,
                Image = p.Image,
                
            }).ToListAsync();
        }

        if (predicate == "likedBy")
        {
            likes = likes.Where(like => like.ProductId == productId);
            users = likes.Select(like => like.User);
            return await users.Select(u => new DtoLike
            {
                Id = u.Id,
                Username = u.UserName,
                Image = u.Image
            }).ToListAsync();
        }

        return null;
    }
}