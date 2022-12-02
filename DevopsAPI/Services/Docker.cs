using DevopsAPI.Factory;
using DevopsAPI.Helper;
using DevopsAPI.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace DevopsAPI.Services
{
    public class Docker : ITerminal
    {
        private readonly GenerateOptions _options;
        private readonly ICommand _command;
        public Docker(IOptions<GenerateOptions> options, ICommand command)
        {
            _options = options.Value;
            _command = command;
        }
        public async Task<Response> CreateTerminal()
        {
            var (name, port) = Utility.GenerateNameAndPort(_options.Characters);
            await Task.WhenAll(new[]
            {
                File.WriteAllTextAsync("name.env", $"name={name}"),
                File.WriteAllTextAsync("port.env", $"port={port}")
            });

            await _command.ExecuteProcess("/tmp/run-container.sh");
            return new Response(HttpStatusCode.OK, new
            {
                Location = $"{_options.Location}:{port}"
            });
        }
    }
}
