using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services;
using System.Linq.Expressions;

namespace PursuitPal.Tests.Services
{
    public class UsersServiceTests
    {
        private readonly UsersService _sut;
        private readonly IRepository<User> _usersRepository;
        private readonly IConfiguration _configuration;

        public UsersServiceTests()
        {
            _usersRepository = Substitute.For<IRepository<User>>();
            _configuration = Substitute.For<IConfiguration>();

            _usersRepository
                .AddAsync(Arg.Any<User>())
                .Returns(new User { Id = Guid.NewGuid() });

            _sut = new UsersService(_usersRepository, _configuration);
        }

        [Fact]
        public async Task RegisterUser_Handle_WhenUserIsCreatedSuccessfully_ShouldReturnUserId()
        {
            var act = async () => await _sut.RegisterUserAsync(Request);

            await act.Should().NotThrowAsync();
            await _usersRepository.Received().AddAsync(Arg.Any<User>());
        }

        [Fact]
        public async Task RegisterUser_Handle_WhenUserIsNotCreatedSuccessfully_ShouldThrowFailedCreationException()
        {
            _usersRepository
                .AddAsync(Arg.Any<User>())
                .Returns(default(User));

            var act = async () => await _sut.RegisterUserAsync(Request);

            await act.Should().ThrowAsync<FailedCreationException>();
        }

        [Fact]
        public async Task GenerateUserToken_Handle_WhenUserIsNotFoundByEmail_ShouldThrowFailedAuthenticationException()
        {
            await _usersRepository
                .FindAsync(Arg.Is<Expression<Func<User, bool>>>(expr =>
                    expr.Compile()(null)));

            var act = async () => await _sut.GenerateUserTokenAsync(TokenRequest);

            await act.Should().ThrowAsync<FailedAuthenticationException>();
        }

        [Fact]
        public async Task GenerateUserToken_Handle_WhenPasswordDoesNotMatch_ShouldThrowFailedAuthenticationException()
        {
            var email = "test@test.com";

            await _usersRepository
                .FindAsync(Arg.Is<Expression<Func<User, bool>>>(expr =>
                    expr.Compile()(new User { Id = Guid.NewGuid(), Email = email })));

            var act = async () => await _sut.GenerateUserTokenAsync(TokenRequest);

            await act.Should().ThrowAsync<FailedAuthenticationException>();
        }

        private CreateUpdateUserRequest Request => new CreateUpdateUserRequest
        {
            Email = "Test",
            FirstName = "Test",
            LastName = "Test",
            Password = "Test",
        };

        private GenerateUserTokenRequest TokenRequest => new GenerateUserTokenRequest
        {
            Email = "test@test.com",
            Password = "test_password",
        };
    }
}
