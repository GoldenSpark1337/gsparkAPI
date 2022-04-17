using gspark.Domain.Models;
using gspark.Service.Specification;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service;

public class SpecificationEvaluator<TEntity> where TEntity : class, IBaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // entity.Id == query.id
        }
        
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // entity => entity.Id
        }
        
        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending); // entity => entity.Id
        }

        if (spec.isPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}