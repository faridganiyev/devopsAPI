using DevopsAPI.Data;
using DevopsAPI.Factory;
using DevopsAPI.Models.Base;
using DevopsAPI.Services.Classes;
using DevopsAPI.Services.Implementations;
using DevopsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevopsAPI.Installers
{
    public static class ServiceInstaller
    {
        public static IServiceCollection ContainerInstaller(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ConnStr")));
            services.Configure<GenerateOptions>(configuration.GetSection("GenerateOptions"));
            services.Configure<MailOptions>(configuration.GetSection("MailOptions"));
            services.AddScoped<IMailer, MailService>();
            services.AddScoped<IToken, TokenHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMembership, MembershipService>();
            services.AddScoped<IAccount, AccountService>();
            services.AddScoped<IAccount, AccountService>();
            services.AddScoped<IRunner, Runner>();

            services.AddScoped<IRunnerFactory, RunnerFactory>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            return services;
        }
    }
}
