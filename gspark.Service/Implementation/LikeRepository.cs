using gspark.Domain.Models;
using gspark.Repository;
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
    public async Task<Product> GetProductWithLikes(int userId)
    {
        return await _context.Products
            .Include(x => x.Likes)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public Task<IEnumerable<DtoLike>> GetProductLikes(string predicate, int productId)
    {
        var products = _context.Products.OrderBy(u => u.Title).AsQueryable();
        var likes = _context.Likes.AsQueryable();

        if (predicate == "liked")
        {
            // current user favourite products
            likes = likes.Where(like => like.UserId == productId);
            products = likes.Select(like => like.Product);
        }

        if (predicate == "likedBy")
        {
        //     likes = likes.Where(like => like.ProductId == productId);
        //     products = likes.Select(like => like.UserId);
        }

        throw new NotImplementedException();
    }
}