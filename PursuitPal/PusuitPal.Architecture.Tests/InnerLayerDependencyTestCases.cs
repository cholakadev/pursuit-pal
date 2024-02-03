using System.Collections;

namespace PusuitPal.Architecture.Tests
{
    public class InnerLayerDependencyTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                ProjectTypesFixture.PursuitPalCoreAssembly,
                new[]
                {
                    ProjectTypesFixture.PursuitPalInfrastructureAssembly,
                    ProjectTypesFixture.PursuitPalPresentationApiAssembly,
                    ProjectTypesFixture.PursuitPalServicesAssembly
                }
            };
            yield return new object[]
            {
                ProjectTypesFixture.PursuitPalServicesAssembly,
                new[]
                {
                    ProjectTypesFixture.PursuitPalInfrastructureAssembly,
                    ProjectTypesFixture.PursuitPalPresentationApiAssembly
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
