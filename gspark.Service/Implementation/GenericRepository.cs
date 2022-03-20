using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Specification;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly MarketPlaceContext _context;

    public GenericRepository(MarketPlaceContext context)
    {
        _context = context;
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity ?? throw new NotFoundException(nameof(entity), id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }

    public async Task<int> AddEntityAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateEntityAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null || entity.Id != id) throw new NotFoundException(nameof(entity), id);
        
    }

    public void DeleteAsync(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity == null || entity.Id != id) throw new NotFoundException(nameof(entity), id);
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
    
    
}