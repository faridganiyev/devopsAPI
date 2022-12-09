using DevopsAPI.Models;
using DevopsAPI.Services.Interfaces;

namespace DevopsAPI.Factory
{
    public interface IRunnerFactory
    {
        IRunner Create(ContainerType token);
    }
}
