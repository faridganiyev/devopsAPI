using System.Diagnostics;

namespace DevopsAPI.Services
{
    public class Command : ICommand
    {
        public async Task<bool> ExecuteProcess(string command)
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
