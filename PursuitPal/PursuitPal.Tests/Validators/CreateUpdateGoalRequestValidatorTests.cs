using FluentValidation.TestHelper;
using PursuitPal.Core.Requests;
using PursuitPal.Presentation.Api.Validators;

namespace PursuitPal.Tests.Validators
{
    public class CreateUpdateGoalRequestValidatorTests
    {
        private readonly CreateUpdateGoalRequestValidator _validator;

        public CreateUpdateGoalRequestValidatorTests()
        {
            _validator = new CreateUpdateGoalRequestValidator();
        }

        [Fact]
        public void Handle_WhenRequestIsValid_ShouldNotHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(20),
                Name = "test",
                Description = "test",
                CompletionCriteria = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Handle_WhenFromDateIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                ToDate = DateTime.Now.AddDays(20),
                Name = "test",
                Description = "test",
                CompletionCriteria = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.FromDate);
        }

        [Fact]
        public void Handle_WhenToDateIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                FromDate = DateTime.Now,
                Name = "test",
                Description = "test",
                CompletionCriteria = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.ToDate);
        }

        [Fact]
        public void Handle_WhenNameIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(20),
                Description = "test",
                CompletionCriteria = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Handle_WhenDescriptionIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(20),
                Name = "test",
                CompletionCriteria = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Handle_WhenCompletionCriteriaIsInvalid_ShouldHaveValidationError()
        {
            var request = new CreateUpdateGoalRequest
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(20),
                Name = "test",
                Description = "test",
            };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.CompletionCriteria);
        }
    }
}
