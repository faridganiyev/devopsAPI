using DevopsAPI.Data.Entities;
using DevopsAPI.Data.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DevopsAPI.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task<int> CountAsync(ISpecifications<T> specification) => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).CountAsync();

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T?> GetBySpecifications(ISpecifications<T> specification) => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> GetListAsync(ISpecifications<T> specification) => await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).ToListAsync();

        public void Update(T entity)
        {
            _context.Attach<T>(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
