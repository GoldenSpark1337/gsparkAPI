using gspark.Domain.Models;
using gspark.Service.Implementation;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Contract;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T: BaseEntity;
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}