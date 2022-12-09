using DevopsAPI.Models;

namespace DevopsAPI.Services.Interfaces
{
    public interface IRunner
    {
        Task<Response> Create(ContainerType type);

        Task<bool> ExecuteCommand(string command);

    }
}
