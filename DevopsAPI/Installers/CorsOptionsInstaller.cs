namespace DevopsAPI.Installers
{
    public static class CorsOptionsInstaller
    {
        public static IServiceCollection CorsInstaller(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("devopsAPI",
                builder =>
                {
                    builder.WithOrigins("https://localhost:3000");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                });
            });
            services.AddSwaggerGen();
            return services;
        }

    }
}
