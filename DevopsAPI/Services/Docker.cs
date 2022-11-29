using DevopsAPI.Factory;
using DevopsAPI.Models;
using System.Text;

namespace DevopsAPI.Services
{
    public class Docker : ITerminal
    {
        private readonly IConfiguration _configuration;
        private readonly ICommand _command;
        public Docker(IConfiguration configuration, ICommand command)
        {
            _configuration = configuration;
            _command = command;
        }
        public async Task<Response> CreateTerminal()
        {
            
            var nameBuilder = new StringBuilder();
            var chars = _configuration.GetSection("CharactersForName").Value.ToCharArray();
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                nameBuilder.Append(chars[rand.Next(0, chars.Length - 1)]);
            }

            var name = nameBuilder.ToString();
            await File.WriteAllTextAsync("name.env", name);

            var port = rand.Next(8001, 65535);
            await File.WriteAllTextAsync("port.env", port.ToString());


            await _command.ExecuteProcess("/tmp/run-container.sh");

            //location href to http://192.168.122.161:${port}

            return new Response
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = new
                {
                    location = $"http://192.168.122.161:{port}"
                }
            };
        }
    }
}
