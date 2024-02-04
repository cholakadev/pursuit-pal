using FluentValidation.TestHelper;
using PursuitPal.Core.Requests;
using PursuitPal.Presentation.Api.Validators;

namespace PursuitPal.Tests.Validators
{
    public class CreateUpdateUserRequestValidatorTests
    {
        private readonly CreateUpdateUserRequestValidator _validator;

        public CreateUpdateUserRequestValidatorTests()
        {
            _validator = new CreateUpdateUserRequestValidator();
        }

        [Fact]
        public void Handle_WhenRequestIsValid_ShouldNotHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                Position = "Test",
                DepartmentId = 1,
                Password = "test_password"
            };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Handle_WhenFirstNameIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                LastName = "Test",
                Email = "test@test.com",
                Position = "Test",
                DepartmentId = 1,
                Password = "test_password"
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void Handle_WhenLastNameIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                Email = "test@test.com",
                Position = "Test",
                DepartmentId = 1,
                Password = "test_password"
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Handle_WhenEmailIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = string.Empty,
                Position = "Test",
                DepartmentId = 1,
                Password = "test_password"
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Handle_WhenPasswordIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Position = "Test",
                Email = "test@test.com",
                DepartmentId = 1,
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Handle_WhenPositionIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                Password = "test_password",
                DepartmentId = 1,
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Position);
        }

        [Fact]
        public void Handle_WhenDepartmentIdIsNotPresent_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                Position = "Test",
                Password = "test_password",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.DepartmentId);
        }

        [Fact]
        public void Handle_WhenDepartmentIdIsNotLessThan0_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                Position = "Test",
                DepartmentId = -1,
                Password = "test_password",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.DepartmentId);
        }

        [Fact]
        public void Handle_WhenDepartmentIdIsEqualTo0_ShouldHaveValidationError()
        {
            var request = new CreateUpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test.com",
                Position = "Test",
                DepartmentId = 0,
                Password = "test_password",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.DepartmentId);
        }
    }
}