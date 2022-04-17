using gspark.Domain.Models;
using gspark.Service.Dtos.LikeDtos;

namespace gspark.Service.Contract;

public interface ILikesRepository
{
    Task<UserProductLike> GetUserLike(int userId, int productId);
    Task<User> GetUserWithLikes(int userId);
    Task<IEnumerable<DtoLike>> GetProductLikes(string predicate, int productId);
}