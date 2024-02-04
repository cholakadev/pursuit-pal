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
                Email = "test@test.com",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }
    }
}