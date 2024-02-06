using NetArchTest.Rules;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Presentation.Api.Controllers;
using PursuitPal.Services;
using System.Reflection;

namespace PusuitPal.Architecture.Tests
{
    public class ProjectTypesFixture
    {
        public Types AllTypes;
        public static Assembly PursuitPalCoreAssembly = typeof(CreateGoalRequest).Assembly;
        public static Assembly PursuitPalInfrastructureAssembly = typeof(Goal).Assembly;
        public static Assembly PursuitPalPresentationApiAssembly = typeof(GoalsController).Assembly;
        public static Assembly PursuitPalServicesAssembly = typeof(GoalsService).Assembly;

        public ProjectTypesFixture()
        {
            AllTypes = Types.InAssemblies(new List<Assembly> {
                PursuitPalCoreAssembly,
                PursuitPalInfrastructureAssembly,
                PursuitPalPresentationApiAssembly,
                PursuitPalServicesAssembly,
            });
        }
    }
}
