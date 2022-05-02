using System.Collections;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Contract;
using Microsoft.Extensions.Logging;

namespace gspark.Service.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly MarketPlaceContext _dbContext;
    private readonly IMapper _mapper;
    private Hashtable _repositories;

    public UnitOfWork(MarketPlaceContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IGenericRepository<T> Repository<T>() where T : class, IBaseEntity
    {
        if (_repositories == null) _repositories = new Hashtable();

        var type = typeof(T).Name;
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
            
            _repositories.Add(type, repositoryInstance);
        }
        
        return (IGenericRepository<T>) _repositories[type];
    }

    public IUserRepository UserRepository => new UserService(_dbContext, _mapper);
    public ITrackRepository TrackRepository { get; }
    public IMessageRepository MessageRepository => new MessageRepository(_dbContext, _mapper);
    public ILikesRepository LikesRepository => new LikeRepository(_dbContext);

    public async Task<bool> Complete()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _dbContext.ChangeTracker.HasChanges();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
