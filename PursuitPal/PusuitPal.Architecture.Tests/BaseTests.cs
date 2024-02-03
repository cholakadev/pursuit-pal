using NetArchTest.Rules;
using System.Reflection;

namespace PusuitPal.Architecture.Tests
{
    public class BaseTests
    {
        protected readonly Types AllTypes;
        protected readonly Assembly PursuitPalCoreAssembly;
        protected readonly Assembly PursuitPalInfrastructureAssembly;
        protected readonly Assembly PursuitPalPresentationApiAssembly;
        protected readonly Assembly PursuitPalServicesAssembly;

        public BaseTests(ProjectTypesFixture fixtures)
        {
            ArgumentNullException.ThrowIfNull(fixtures);
            AllTypes = fixtures.AllTypes;
            PursuitPalCoreAssembly = ProjectTypesFixture.PursuitPalCoreAssembly;
            PursuitPalInfrastructureAssembly = ProjectTypesFixture.PursuitPalInfrastructureAssembly;

            PursuitPalPresentationApiAssembly = ProjectTypesFixture.PursuitPalPresentationApiAssembly;
            PursuitPalServicesAssembly = ProjectTypesFixture.PursuitPalServicesAssembly;
        }
    }
}
