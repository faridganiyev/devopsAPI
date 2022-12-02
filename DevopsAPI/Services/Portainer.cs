using DevopsAPI.Factory;
using DevopsAPI.Helper;
using DevopsAPI.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace DevopsAPI.Services
{
    public class Portainer : ITerminal
    {
        private readonly GenerateOptions _options;
        private readonly ICommand _command;
        public Portainer(IOptions<GenerateOptions> options, ICommand command)
        {
            _options = options.Value;
            _command = command;
        }
        public async Task<Response> CreateTerminal()
        {
            var (name, port) = Utility.GenerateNameAndPort(_options.Characters);
            await Task.WhenAll(new[]
            {
                File.WriteAllTextAsync("portainername.env", name),
                File.WriteAllTextAsync("portainerport.env", port.ToString())
            });
            await _command.ExecuteProcess("/tmp/run-portainer.sh");

            return new Response(HttpStatusCode.OK, new
            {
                Locations = $"{_options.Location}:{port}"
            });
        }
    }
}
