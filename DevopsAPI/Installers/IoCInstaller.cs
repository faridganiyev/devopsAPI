using DevopsAPI.Data;
using DevopsAPI.Factory;
using DevopsAPI.Models;
using DevopsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace DevopsAPI.Installers
{
    public class IoCInstaller
    {
        public static void AddIoC(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnStr")));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<GenerateOptions>(builder.Configuration.GetSection("GenerateOptions"));
            builder.Services.AddSingleton<ICommand, Command>();
            builder.Services.AddScoped<ITerminal, Docker>();
            builder.Services.AddScoped<ITerminal, Portainer>();
            builder.Services.AddScoped<ITerminalFactory, TerminalFactory>();
        }
    }
}
