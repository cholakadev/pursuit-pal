using FluentAssertions;
using PursuitPal.Core.Models;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Tests.Factories
{
    public class UserFactoryTests
    {
        private readonly CreateUpdateUserRequest _createUpdateUserRequest;
        private readonly User _user;

        public UserFactoryTests()
        {
            _createUpdateUserRequest = new CreateUpdateUserRequest
            {
                Email = "test",
                FirstName = "Test",
                LastName = "Test",
            };

            _user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Email = "test",
            };
        }

        [Fact]
        public void Handle_WhenConvertingValidRequestToEntity_ShouldReturnUserEntity()
        {
            var password = "test_password";
            var salt = "test_salt";

            var entity = _createUpdateUserRequest.ToEntity(password, salt);
            entity.Should().BeOfType<User>();
            entity.FirstName.Should().Be(_createUpdateUserRequest.FirstName);
            entity.LastName.Should().Be(_createUpdateUserRequest.LastName);
            entity.Email.Should().Be(_createUpdateUserRequest.Email);
            entity.Password.Should().Be(password);
            entity.Salt.Should().Be(salt);
        }

        [Fact]
        public void Handle_WhenConvertingNullRequestToEntity_ShouldThrowException()
        {
            CreateUpdateUserRequest? request = null;
            string password = "test_password";
            var salt = "test_salt";

            Assert.Throws<ArgumentNullException>(() => request.ToEntity(password, salt));
        }

        [Fact]
        public void Handle_WhenConvertingRequestToEntityWithInvalidPassword_ShouldThrowException()
        {
            string? password = null;
            var salt = "test_salt";

            Assert.Throws<ArgumentNullException>(() => _createUpdateUserRequest.ToEntity(password, salt));
        }

        [Fact]
        public void Handle_WhenConvertingRequestToEntityWithInvalidSalt_ShouldThrowException()
        {
            var password = "test_password";
            string? salt = null;

            Assert.Throws<ArgumentNullException>(() => _createUpdateUserRequest.ToEntity(password, salt));
        }

        [Fact]
        public void Handle_WhenConvertingValidEntityToUserModel_ShouldReturnUserModel()
        {
            var userModel = _user.ToModel();
            userModel.Should().BeOfType<UserModel>();
            userModel.FirstName.Should().Be(_user.FirstName);
            userModel.LastName.Should().Be(_user.LastName);
            userModel.Email.Should().Be(_user.Email);
        }

        [Fact]
        public void Handle_WhenConvertingNullEntityToUserModel_ShouldThrowException()
        {
            User? user = null;
            Assert.Throws<ArgumentNullException>(() => user.ToModel());
        }
    }
}
