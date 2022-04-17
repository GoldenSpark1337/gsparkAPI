using gspark.Domain.Models;
using gspark.Service.Specification;

namespace gspark.Service.Contract;

public interface IGenericRepository<T> where T : class, IBaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetEntityWithSpecification(ISpecification<T> specification);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    Task<int> CountAsync(ISpecification<T> spec);
    Task<int> AddEntityAsync(T entity);
    Task UpdateEntityAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void DeleteAsync(int id);
}