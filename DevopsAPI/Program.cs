using DevopsAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.ContainerInstaller(builder.Configuration);
builder.Services.IdentityInstaller(builder.Configuration);
builder.Services.CorsInstaller();
builder.Services.SwaggerInstaller();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddlewares();

app.Run();
