using NetArchTest.Rules;
using PusuitPal.Architecture.Tests.Extensions;
using System.Reflection;
using Xunit;

namespace PusuitPal.Architecture.Tests
{
    [Collection("Project Types")]
    public class DependencyTests : BaseTests
    {
        public DependencyTests(ProjectTypesFixture fixtures)
            : base(fixtures)
        {
        }

        [Fact]
        public void CoreLayerShouldNotHaveDependencyOnOuterLayers()
        {
            var outerLayerAssemblies = new List<Assembly>
            {
                ProjectTypesFixture.PursuitPalServicesAssembly,
                ProjectTypesFixture.PursuitPalPresentationApiAssembly,
                ProjectTypesFixture.PursuitPalInfrastructureAssembly,
            };

            var outerLayerTypes = outerLayerAssemblies
                .SelectMany(a => a.GetTypes()
                    .Where(t => t != null && t.FullName != null &&
                                t.FullName.StartsWith(a.GetName().Name)))
                .Select(t => t.FullName)
                .ToArray();

            Types.InAssembly(ProjectTypesFixture.PursuitPalCoreAssembly)
                .Should().NotHaveDependencyOnAll(outerLayerTypes)
                .AssertIsSuccessful();
        }
    }
}
