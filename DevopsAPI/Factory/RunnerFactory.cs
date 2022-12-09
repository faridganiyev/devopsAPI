using DevopsAPI.Models;
using DevopsAPI.Services.Interfaces;

namespace DevopsAPI.Factory
{
    public class RunnerFactory : IRunnerFactory
    {
        private readonly IEnumerable<IRunner> _runnerServices;

        public RunnerFactory(IEnumerable<IRunner> runnerServices)
        {
            _runnerServices = runnerServices;
        }

        public IRunner Create(ContainerType token) => token switch
        {
            //ContainerType.docker => GetService(typeof(Docker)),
            //ContainerType.portainer => GetService(typeof(Portainer)),
            _ => throw new InvalidOperationException()
        };

        private IRunner GetService(Type type) => _runnerServices.FirstOrDefault(x => x.GetType() == type)!;
    }
}
