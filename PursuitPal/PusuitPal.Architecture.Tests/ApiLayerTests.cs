using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Presentation.Api.Validators;
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
        public void ApiControllersShouldResideInPresentationApi()
        {
            AllTypes.That().Inherit(typeof(Controller))
                .Should().ResideInNamespaceContaining("Presentation.Api")
                .AssertIsSuccessful();
        }

        [Fact]
        public void ValidatorsShouldResideInPresentationApi()
        {
            AllTypes.That().Inherit(typeof(BaseValidator<>))
                .Should().ResideInNamespaceContaining("Presentation.Api")
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
        public void RequestsShouldResideInCore()
        {
            AllTypes.That().HaveNameEndingWith("Request")
                .Should().ResideInNamespaceContaining("Core.Requests")
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
        public void ResponsesShouldResideInCore()
        {
            AllTypes.That().HaveNameEndingWith("Response")
                .Should().ResideInNamespaceContaining("Core.Responses")
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
        public void EntityConfigurationsShouldResideInInfrastructureConfigurations()
        {
            AllTypes.That().ImplementInterface(typeof(IEntityTypeConfiguration<>))
                .Should().ResideInNamespaceContaining("Infrastructure.Configurations")
                .AssertIsSuccessful();
        }

        [Fact]
        public void EntitiesShouldResideInInfrastructureEntities()
        {
            AllTypes.That().Inherit(typeof(Auditable))
                .Should().ResideInNamespaceContaining("Infrastructure.Entities")
                .AssertIsSuccessful();
        }

        [Fact]
        public void RepositoriesShouldResideInRepositories()
        {
            AllTypes.That().ImplementInterface(typeof(IRepository<>))
                .Should().ResideInNamespaceContaining("Infrastructure.Repositories")
                .AssertIsSuccessful();
        }

        [Fact]
        public void DbContextShouldResideInInfrastructure()
        {
            AllTypes.That().Inherit(typeof(DbContext))
                .Should().ResideInNamespaceContaining("Infrastructure")
                .AssertIsSuccessful();
        }

        [Fact]
        public void FactoriesShouldResideInServices()
        {
            AllTypes.That().HaveNameEndingWith("Factory")
                .Should().ResideInNamespaceContaining("Services.Factories")
                .AssertIsSuccessful();
        }
    }
}