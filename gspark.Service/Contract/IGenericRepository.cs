using gspark.Domain.Models;
using gspark.Service.Specification;

namespace gspark.Service.Contract;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetEntityWithSpecification(ISpecification<T> specification);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    Task<int> AddEntityAsync(T entity);
    Task UpdateEntityAsync(int id);
    void DeleteAsync(int id);
}