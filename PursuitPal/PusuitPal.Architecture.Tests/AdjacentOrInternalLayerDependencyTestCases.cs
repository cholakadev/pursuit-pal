using System.Collections;

namespace PusuitPal.Architecture.Tests
{
    public class AdjacentOrInternalLayerDependencyTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                ProjectTypesFixture.PursuitPalPresentationApiAssembly,
                new[]
                {
                    ProjectTypesFixture.PursuitPalInfrastructureAssembly,
                    ProjectTypesFixture.PursuitPalServicesAssembly
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
