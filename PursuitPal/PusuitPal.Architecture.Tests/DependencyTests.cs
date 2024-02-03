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

        [Theory]
        [ClassData(typeof(InnerLayerDependencyTestCases))]
        public void InnerLayerShouldNotDependOnOuterLayers(Assembly? innterTypeAssembly, Assembly[] outerLayersAssemblies)
        {
            var outerLayersTypes = outerLayersAssemblies
                .SelectMany(a => a.GetTypes()
                    .Where(t => t != null && t.FullName != null &&
                                t.FullName.StartsWith(a.GetName().Name)))
                .Select(t => t.FullName)
                .ToArray();

            var innterTypes = Types.InAssembly(innterTypeAssembly);

            innterTypes
                    .Should().NotHaveDependencyOnAny(outerLayersTypes)
                    .GetResult();
        }

        [Theory]
        [ClassData(typeof(AdjacentOrInternalLayerDependencyTestCases))]
        public void TargetLayerShouldNotAccessAdjacentOrInnerLayers(Assembly? targetAssembly, Assembly[] adjacentOrInternalAssemblies)
        {
            var apiTypes = Types.InAssembly(targetAssembly);

            var infrastructureTypes = Types.InAssemblies(adjacentOrInternalAssemblies)
                .GetTypes()
                .Select(t => t.FullName)
                .ToArray();

            apiTypes
                .That().DoNotHaveName("Program")
                .And().DoNotHaveName("ServiceCollectionExtensions")
                .Should().NotHaveDependencyOnAny(infrastructureTypes)
                .AssertIsSuccessful();
        }
    }
}
