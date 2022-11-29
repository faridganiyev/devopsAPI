using DevopsAPI.Services;

namespace DevopsAPI.Factory
{
    public interface ITerminalFactory
    {
        ITerminal Create(string token);
    }
}
