using DevopsAPI.Data;
using DevopsAPI.UnitOfWork;

namespace Template.NET.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private bool disposed;

        //public IRepository<Test> _testRepo;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IRepository<Test> TestRepo => _testRepo ??= new Repository<Test>(_dbContext);

        public AppDbContext GetContext() => _dbContext;

        public async Task<bool> Complete() => await _dbContext.SaveChangesAsync() > 0;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
