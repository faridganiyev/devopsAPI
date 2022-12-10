using DevopsAPI.Helper;
using DevopsAPI.Models.Base;
using DevopsAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;

namespace DevopsAPI.Services.Implementations
{
    public class Runner : IRunner
    {
        private readonly GenerateOptions _options;
        public Runner(IOptions<GenerateOptions> options)
        {
            _options = options.Value;
        }

        public async Task<Response> Create(ContainerType type)
        {
            var (name, port) = Utility.GenerateNameAndPort(_options.Characters);
            await Task.WhenAll(new[]
            {
                File.WriteAllTextAsync($"{type}_name.env", $"name={name}"),
                File.WriteAllTextAsync($"{type}_port.env", $"port={port}")
            });

            await ExecuteCommand($"/tmp/run-{type}.sh");
            return new Response(HttpStatusCode.OK, new
            {
                Location = $"{_options.Location}:{port}"
            });
        }

        public async Task<bool> ExecuteCommand(string command)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };
            process.Start();
            await process.StandardInput.WriteLineAsync(command);
            var output = await process.StandardOutput.ReadLineAsync();
            Console.WriteLine(output);
            return output != null;
        }
    }
}
