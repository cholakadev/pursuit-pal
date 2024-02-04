using PursuitPal.Core.Requests;

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
            RuleFor(x => x.Password).ShouldNotBeEmpty();
        }
    }
}
