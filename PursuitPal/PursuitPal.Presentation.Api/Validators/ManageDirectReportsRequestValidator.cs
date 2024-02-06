using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Validators
{
    public class ManageDirectReportsRequestValidator : BaseValidator<ManageDirectReportsRequest>
    {
        public ManageDirectReportsRequestValidator()
        {
            RuleFor(x => x.UserIds).ShouldNotBeEmpty();
        }
    }
}
