using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services;

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
        public async Task Handle_WhenUserIsCreatedSuccessfully_ShouldReturnUserId()
        {
            var act = async () => await _sut.RegisterUserAsync(Request);

            await act.Should().NotThrowAsync();
            await _usersRepository.Received().AddAsync(Arg.Any<User>());
        }

        [Fact]
        public async Task Handle_WhenUserIsNotCreatedSuccessfully_ShouldThrowFailedCreationException()
        {
            _usersRepository
                .AddAsync(Arg.Any<User>())
                .Returns(default(User));

            var act = async () => await _sut.RegisterUserAsync(Request);

            await act.Should().ThrowAsync<FailedCreationException>();
        }

        private CreateUpdateUserRequest Request => new CreateUpdateUserRequest
        {
            Email = "Test",
            FirstName = "Test",
            LastName = "Test",
            Password = "Test",
        };
    }
}
