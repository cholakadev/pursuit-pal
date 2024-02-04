using FluentValidation.TestHelper;
using PursuitPal.Core.Requests;
using PursuitPal.Presentation.Api.Validators;

namespace PursuitPal.Tests.Validators
{
    public class GenerateUserTokenRequestValidatorTests
    {
        private readonly GenerateUserTokenRequestValidator _validator;

        public GenerateUserTokenRequestValidatorTests()
        {
            _validator = new GenerateUserTokenRequestValidator();
        }

        [Fact]
        public void Handle_WhenRequestIsValid_ShouldNotHaveValidationError()
        {
            var request = new GenerateUserTokenRequest
            {
                Email = "test@test.com",
                Password = "test_password",
            };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Handle_WhenEmailIsInvalid_ShouldHaveValidationError()
        {
            var request = new GenerateUserTokenRequest
            {
                Email = string.Empty,
                Password = "test_password",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Handle_WhenPasswordIsInvalid_ShouldHaveValidationError()
        {
            var request = new GenerateUserTokenRequest
            {
                Email = "test@test.com",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }
    }
}
