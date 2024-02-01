using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Repositories;
using PursuitPal.Core.Services;
using PursuitPal.Infrastructure;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Infrastructure.Repositories;
using PursuitPal.Presentation.Api.Validators;
using PursuitPal.Services;

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

        /// <summary>Configure dependency injection for Services.</summary>
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
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

        public static void AddValidatorsConfiguration(this IServiceCollection services)
        {
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

            ValidatorOptions.Global.DisplayNameResolver = (_, member, _)
                => member != null ? member.Name.Replace(" ", string.Empty) : null;

            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblyContaining<BaseValidator<object>>();
        }
    }
}
