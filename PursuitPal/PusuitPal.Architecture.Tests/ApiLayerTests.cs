using Microsoft.AspNetCore.Mvc;
using PusuitPal.Architecture.Tests.Extensions;
using Xunit;

namespace PusuitPal.Architecture.Tests
{
    [Collection("Project Types")]
    public class ApiLayerTests : BaseTests
    {
        public ApiLayerTests(ProjectTypesFixture fixtures)
            : base(fixtures)
        {
        }

        [Fact]
        public void ApiControllersShouldOnlyResideInApi()
        {
            AllTypes.That().Inherit(typeof(Controller))
                .Should().ResideInNamespaceEndingWith("Presentation.Api.Controllers")
                .AssertIsSuccessful();
        }

        [Fact]
        public void AllApiControllersMustInheritController()
        {
            AllTypes.That().ResideInNamespaceEndingWith("Presentation.Api.Controllers")
                .Should().Inherit(typeof(Controller))
                .AssertIsSuccessful();
        }
    }
}