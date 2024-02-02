using FluentValidation;

namespace PursuitPal.Presentation.Api.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
        where T : class
    {
    }
}
