namespace DevopsAPI.Installers
{
    public static class MiddlewareInstaller
    {
        public static WebApplication UseMiddlewares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
