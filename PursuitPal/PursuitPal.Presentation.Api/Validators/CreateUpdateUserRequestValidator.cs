using PursuitPal.Core.Requests;
using FluentValidation;

namespace PursuitPal.Presentation.Api.Validators
{
    public class CreateUpdateUserRequestValidator : BaseValidator<CreateUpdateUserRequest>
    {
        public CreateUpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).ShouldNotBeEmpty();
            RuleFor(x => x.LastName).ShouldNotBeEmpty();
            RuleFor(x => x.Email).MustBeAValidEmailAddress();
            RuleFor(x => x.Position).ShouldNotBeEmpty();
            RuleFor(x => x.DepartmentId).ShouldNotBeEmpty().GreaterThan(0);
            RuleFor(x => x.Password).ShouldNotBeEmpty();
        }
    }
}
