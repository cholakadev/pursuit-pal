using Microsoft.AspNetCore.Mvc;
using NetArchTest.Rules;
using PursuitPal.Core.Contracts;
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

        [Fact]
        public void ApiControllersShouldEndWithController()
        {
            AllTypes.That().Inherit(typeof(Controller))
                .Should().HaveNameEndingWith("Controller")
                .AssertIsSuccessful();
        }

        [Fact]
        public void RequestsShouldResideInCore()
        {
            AllTypes.That().ImplementInterface(typeof(IRequest))
                .Should().ResideInNamespaceContaining("PursuitPal.Core.Requests")
                .AssertIsSuccessful();
        }

        [Fact]
        public void ResponsesShouldResideInCore()
        {
            AllTypes.That().ImplementInterface(typeof(IResponse))
                .Should().ResideInNamespaceContaining("PursuitPal.Core.Responses")
                .AssertIsSuccessful();
        }

        [Fact]
        public void ExceptionsShouldResideInCore()
        {
            AllTypes.That().Inherit(typeof(Exception))
                .Should().ResideInNamespaceContaining("PursuitPal.Core.Exceptions")
                .AssertIsSuccessful();
        }
    }
}