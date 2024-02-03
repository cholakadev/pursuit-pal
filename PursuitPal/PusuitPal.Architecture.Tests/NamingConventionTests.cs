using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Contracts.Repositories;
using PusuitPal.Architecture.Tests.Extensions;
using Xunit;

namespace PusuitPal.Architecture.Tests
{
    [Collection("Project Types")]
    public class NamingConventionTests : BaseTests
    {
        public NamingConventionTests(ProjectTypesFixture fixtures)
            : base(fixtures)
        {
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
        public void RequestsShouldEndWithRequest()
        {
            AllTypes.That().ResideInNamespaceContaining("Core.Requests")
                .Should().HaveNameEndingWith("Request")
                .AssertIsSuccessful();
        }

        [Fact]
        public void ResponsesShouldEndWithResponse()
        {
            AllTypes.That().ResideInNamespaceContaining("Core.Responses")
                .Should().HaveNameEndingWith("Response")
                .AssertIsSuccessful();
        }

        [Fact]
        public void ServicesShouldEndWithService()
        {
            AllTypes.That().ResideInNamespaceMatching("PursuitPal.Core.Contracts.Services")
                .Should().HaveNameEndingWith("Service")
                .AssertIsSuccessful();
        }

        [Fact]
        public void RepositoriesShouldResideInRepositories()
        {
            AllTypes.That().ImplementInterface(typeof(IRepository<>))
                .Should().ResideInNamespaceContaining("Infrastructure.Repositories")
                .AssertIsSuccessful();
        }
    }
}