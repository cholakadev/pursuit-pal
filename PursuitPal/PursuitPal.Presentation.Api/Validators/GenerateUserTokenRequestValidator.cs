using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Validators
{
    public class GenerateUserTokenRequestValidator : BaseValidator<GenerateUserTokenRequest>
    {
        public GenerateUserTokenRequestValidator()
        {
            RuleFor(x => x.Email).MustBeAValidEmailAddress();
            RuleFor(x => x.Password).ShouldNotBeEmpty();
        }
    }
}
