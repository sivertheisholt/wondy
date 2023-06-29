using Microsoft.EntityFrameworkCore;
using Wondy.Api.Data;
using Wondy.Api.Helpers;
using Wondy.Api.Interfaces;

namespace Wondy.Api.Extentions
{
 public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<DataContext>(options =>
            {
                string connStr;

                if (env == "Development")
                {
                    connStr = config.GetConnectionString("DefaultConnection")!;
                }
                else
                {
                    connStr = Environment.GetEnvironmentVariable("DB_CONN_STR")!;
                }
                options.UseSqlServer(connStr);
            });

            return services;
        }
    }
}