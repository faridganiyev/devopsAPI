using DevopsAPI.Models;

namespace DevopsAPI.Services.Interfaces
{
    public interface IAccount
    {
        Task<Response> CreateAsync();
        Task<Response> UpdateAsync();
        Task<Response> DeleteAsync();
        Task<Response> LoginAsync();

    }
}
