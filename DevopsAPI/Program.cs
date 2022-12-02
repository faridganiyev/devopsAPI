using DevopsAPI.Factory;
using DevopsAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IoCInstaller.AddIoC(builder);

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

app.MapGet("run-portainer", async (ITerminalFactory terminalFactory) =>
{
    var portainer = terminalFactory.Create("portainer");
    var result = await portainer.CreateTerminal();
    return Results.Ok(result);
});


app.Run();
