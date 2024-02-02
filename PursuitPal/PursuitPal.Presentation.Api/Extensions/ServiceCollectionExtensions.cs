using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PursuitPal.Core.Repositories;
using PursuitPal.Core.Services;
using PursuitPal.Infrastructure;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Infrastructure.Repositories;
using PursuitPal.Presentation.Api.Interceptors;
using PursuitPal.Presentation.Api.Validators;
using PursuitPal.Services;
using System.Reflection;

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
            services.AddScoped<IUsersContextService, UsersContextService>();
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

            services.AddTransient<IValidatorInterceptor, ValidatorInterceptor>();
        }

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the generated user token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                            },
                        },
                        new List<string>()
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}
