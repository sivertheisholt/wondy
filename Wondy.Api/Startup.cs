using Microsoft.EntityFrameworkCore;
using Serilog;
using Wondy.Api.Data;
using Wondy.Api.Extentions;
using Wondy.Api.Interfaces;

namespace Wondy.Api
{
    public static class Startup
    {
        public static Task ConfigureServices(IServiceCollection Services, IConfiguration config)
        {
            Services.AddControllers();

            Services.AddApplicationServices(config);

            Services.AddHealthChecks();
            
            return Task.CompletedTask;
        }
        public static async Task ConfigureDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<DataContext>();

            await context.Database.MigrateAsync();

            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
        }
        public static Task ConfigureMiddleware(WebApplication app)
        {
            // smarter HTTP request logging
            app.UseSerilogRequestLogging();

            if (!app.Environment.IsDevelopment()) app.UseHsts();
            else app.UseExceptionHandler("/home/error-development");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            return Task.CompletedTask;
        }

        public static Task ConfigureLogger(WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

            builder.Host.UseSerilog();

            return Task.CompletedTask;
        }
    }
}