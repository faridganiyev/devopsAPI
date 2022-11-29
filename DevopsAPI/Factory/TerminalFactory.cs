using DevopsAPI.Services;

namespace DevopsAPI.Factory
{
    public class TerminalFactory : ITerminalFactory
    {
        private readonly IEnumerable<ITerminal> _terminalServices;

        public TerminalFactory(IEnumerable<ITerminal> terminalServices)
        {
            _terminalServices = terminalServices;
        }
        public ITerminal Create(string token) => token switch
        {
            "docker" => GetService(typeof(Docker)),
            "portainer" => GetService(typeof(Portainer)),
            _ => throw new InvalidOperationException()
        };

        private ITerminal GetService(Type type) => _terminalServices.FirstOrDefault(x => x.GetType() == type)!;
    }
}
