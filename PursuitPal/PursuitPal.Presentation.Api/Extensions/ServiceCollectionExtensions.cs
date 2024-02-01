using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Repositories;
using PursuitPal.Infrastructure;
using PursuitPal.Infrastructure.Repositories;

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

        /// <summary>Configure dependency injection for Repositories.</summary>
        public static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddPursuitPalApIVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}
