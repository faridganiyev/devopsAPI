using DevopsAPI.Models;
using DevopsAPI.Models.Base;
using DevopsAPI.Services.Interfaces;

namespace DevopsAPI.Factory
{
    public interface IRunnerFactory
    {
        IRunner Create(ContainerType token);
    }
}
