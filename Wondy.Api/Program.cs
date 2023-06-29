using Serilog;
using Wondy.Api;

try
{
    var builder = WebApplication.CreateBuilder(args);

    await Startup.ConfigureLogger(builder);

    await Startup.ConfigureServices(builder.Services, builder.Configuration);

    var app = builder.Build();

    await Startup.ConfigureDatabase(app);

    await Startup.ConfigureMiddleware(app);

    await app.RunAsync();
}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}