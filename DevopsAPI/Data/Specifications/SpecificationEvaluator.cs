using Microsoft.EntityFrameworkCore;
using DevopsAPI.Data.Entities;

namespace DevopsAPI.Data.Specifications
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> specification)
        {
            var query = inputQuery.AsQueryable();

            if (specification.Criteria != null)
                query = query.Where(specification.Criteria);
            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);
            if (specification.IsPagingEnabled)
                query = query.Skip(specification.Skip).Take(specification.Take);

            query = specification.Includes.Aggregate(query, (current, includes) => current.Include(includes));

            return query;
        }
    }
}
