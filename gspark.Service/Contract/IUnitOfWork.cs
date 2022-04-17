using gspark.Domain.Models;
using gspark.Service.Implementation;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Contract;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T: class, IBaseEntity;
    IUserRepository UserRepository { get; }
    ITrackRepository TrackRepository { get; }
    IMessageRepository MessageRepository { get; }
    ILikesRepository LikesRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}