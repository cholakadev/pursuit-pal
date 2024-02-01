using FluentValidation;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Validators
{
    public class CreateUpdateUserRequestValidator : BaseValidator<CreateUpdateUserRequest>
    {
        public CreateUpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
