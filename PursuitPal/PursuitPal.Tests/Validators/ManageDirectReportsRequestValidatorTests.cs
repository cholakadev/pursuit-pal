using FluentValidation.TestHelper;
using PursuitPal.Core.Requests;
using PursuitPal.Presentation.Api.Validators;

namespace PursuitPal.Tests.Validators
{
    public class ManageDirectReportsRequestValidatorTests
    {
        private readonly ManageDirectReportsRequestValidator _validator;

        public ManageDirectReportsRequestValidatorTests()
        {
            _validator = new ManageDirectReportsRequestValidator();
        }

        [Fact]
        public void Handle_WhenRequestIsValid_ShouldNotHaveValidationError()
        {
            var request = new ManageDirectReportsRequest
            {
                UserIds = new List<Guid> { Guid.NewGuid() },
            };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Handle_WhenUserIdsIsNotPresent_ShouldHaveValidationError()
        {
            var request = new ManageDirectReportsRequest();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.UserIds);
        }
    }
}
