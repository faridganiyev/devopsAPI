using DevopsAPI.Models;

namespace DevopsAPI.Factory
{
    public interface ITerminal
    {
        Task<Response> CreateTerminal();

    }
}
