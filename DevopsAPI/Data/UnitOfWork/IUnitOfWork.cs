using DevopsAPI.Data;

namespace DevopsAPI.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<Test> TestRepo { get; }
        AppDbContext GetContext();
        Task<bool> Complete();

    }
}
