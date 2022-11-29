using DevopsAPI.Factory;
using DevopsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICommand, Command>();
builder.Services.AddScoped<ITerminal, Docker>();
builder.Services.AddScoped<ITerminal, Portainer>();
builder.Services.AddScoped<ITerminalFactory, TerminalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//endpoints
app.MapGet("run-docker", async (ITerminalFactory terminalFactory) =>
{
    var docker = terminalFactory.Create("docker");
    var result = await docker.CreateTerminal();
    return Results.Ok(result);
});

//endpoints
app.MapGet("run-portainer", async (ITerminalFactory terminalFactory) =>
{
    var portainer = terminalFactory.Create("portainer");
    var result = await portainer.CreateTerminal();
    return Results.Ok(result);
});

app.Run();
