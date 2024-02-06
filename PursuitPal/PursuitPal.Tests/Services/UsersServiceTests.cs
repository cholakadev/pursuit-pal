using Azure.Core;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MockQueryable.NSubstitute;
using NSubstitute;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace PursuitPal.Tests.Services
{
    public class UsersServiceTests
    {
        private readonly UsersService _sut;
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _usersRepository;
        private readonly IUsersContextService _usersContextService;

        public UsersServiceTests()
        {
            _configuration = Substitute.For<IConfiguration>();
            _usersRepository = Substitute.For<IRepository<User>>();
            _usersContextService  = Substitute.For<IUsersContextService>();

            _usersRepository
                .AddAsync(Arg.Any<User>())
                .Returns(new User { Id = Guid.NewGuid() });

            _sut = new UsersService(
                _configuration,
                _usersRepository,
                _usersContextService);
        }

        [Fact]
        public async Task RegisterUser_Handle_WhenUserIsCreatedSuccessfully_ShouldReturnUserId()
        {
            var act = async () => await _sut.RegisterUserAsync(CreateUpdateRequest);

            await act.Should().NotThrowAsync();
            await _usersRepository.Received().AddAsync(Arg.Any<User>());
        }

        [Fact]
        public async Task RegisterUser_Handle_WhenUserIsNotCreatedSuccessfully_ShouldThrowFailedCreationException()
        {
            _usersRepository
                .AddAsync(Arg.Any<User>())
                .Returns(default(User));

            var act = async () => await _sut.RegisterUserAsync(CreateUpdateRequest);

            await act.Should().ThrowAsync<FailedCreationException>();
        }

        [Fact]
        public async Task GenerateUserToken_Handle_WhenUserIsNotFoundByEmail_ShouldThrowFailedAuthenticationException()
        {
            var mock = new List<User>().BuildMock();

            _usersRepository.GetAll().Include(x => x.Roles).Returns(mock);

            var act = async () => await _sut.GenerateUserTokenAsync(TokenRequest);

            await act.Should().ThrowAsync<FailedAuthenticationException>();
        }

        [Fact]
        public async Task GenerateUserToken_Handle_WhenPasswordDoesNotMatch_ShouldThrowFailedAuthenticationException()
        {
            var pursuitPalHash = new PursuitPalHash();

            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test.com",
                    Password = pursuitPalHash.HashPasword("test123", out byte[] salt),
                    Salt = Convert.ToHexString(salt),
                    Roles = new List<Role>
                    {
                        new Role { RoleName = "test" }
                    }
                },
            };

            var mock = users.BuildMock();

            _usersRepository.GetAll().Include(x => x.Roles).Returns(mock);

            var act = async () => await _sut.GenerateUserTokenAsync(TokenRequest);

            await act.Should().ThrowAsync<FailedAuthenticationException>();
        }

        [Fact]
        public async Task ManageDirectReports_Handle_WhenUserIsAdmin_ShouldSetReportsToDifferentThenTheCurrentUserId()
        {
            _usersContextService.IsInRole("Admin").Returns(true);

            var pursuitPalHash = new PursuitPalHash();
            var password = pursuitPalHash.HashPasword("test123", out byte[] salt);

            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test.com",
                    Password = password,
                    Salt = Convert.ToHexString(salt),
                    Roles = new List<Role>
                    {
                        new Role { RoleName = "test" }
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test2@test.com",
                    Password = password,
                    Salt = Convert.ToHexString(salt),
                    Roles = new List<Role>
                    {
                        new Role { RoleName = "test2" }
                    }
                },
            };

            var mock = users.BuildMock();

            _usersRepository.GetAll().Include(x => x.Roles).Returns(mock);

            _ = await _sut.ManageDirectReportsAsync(ManageDirectReportsRequest);

            await _usersRepository.Received(1).UpdateManyAsync(
                Arg.Is<ICollection<User>>(users =>
                    users.All(user => user.ReportsTo == ManageDirectReportsRequest.ReportsToUserId)));
        }

        [Fact]
        public async Task ManageDirectReports_Handle_WhenUserIsLead_ShouldSetReportsToEqualsToTheCurrentUserId()
        {
            var currentUserId = Guid.NewGuid();
            _usersContextService.UserId.Returns(currentUserId);
            _usersContextService.IsInRole("Admin").Returns(false);

            var pursuitPalHash = new PursuitPalHash();
            var password = pursuitPalHash.HashPasword("test123", out byte[] salt);

            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test.com",
                    Password = password,
                    Salt = Convert.ToHexString(salt),
                    Roles = new List<Role>
                    {
                        new Role { RoleName = "test" }
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test2@test.com",
                    Password = password,
                    Salt = Convert.ToHexString(salt),
                    Roles = new List<Role>
                    {
                        new Role { RoleName = "test2" }
                    }
                },
            };

            var mock = users.BuildMock();

            _usersRepository.GetAll().Include(x => x.Roles).Returns(mock);

            _ = await _sut.ManageDirectReportsAsync(ManageDirectReportsRequest);

            await _usersRepository.Received(1).UpdateManyAsync(
                Arg.Is<ICollection<User>>(users =>
                    users.All(user => user.ReportsTo == currentUserId)));
        }

        private CreateUpdateUserRequest CreateUpdateRequest => new CreateUpdateUserRequest
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

        private ManageDirectReportsRequest ManageDirectReportsRequest => new ManageDirectReportsRequest
        {
            UserIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() },
            ReportsToUserId = Guid.NewGuid()
        };
    }
}
