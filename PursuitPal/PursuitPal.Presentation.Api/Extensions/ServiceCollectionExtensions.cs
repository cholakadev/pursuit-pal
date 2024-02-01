using Microsoft.EntityFrameworkCore;
using PursuitPal.Infrastructure;

namespace PursuitPal.Presentation.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string DefaultConnectionKey = "DefaultConnection";

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PursuitPalDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(DefaultConnectionKey);

                options.UseSqlServer(
                    connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("PursuitPal.Infrastructure");
                    });
            });
        }
    }
}
