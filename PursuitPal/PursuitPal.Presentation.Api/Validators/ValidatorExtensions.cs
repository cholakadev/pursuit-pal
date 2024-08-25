using FluentValidation;
using PursuitPal.Core.Helpers;

namespace PursuitPal.Presentation.Api.Validators
{
    public static class ValidatorExtensions
    {
        private const string InvalidZipCodeErrorMessage = "The email address is invalid.";

        public static IRuleBuilderOptions<T, TElement> ShouldNotBeEmpty<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
            => ruleBuilder.NotEmpty().WithMessage("The {PropertyName} is required.");

        public static IRuleBuilderOptions<T, TProperty> MustBeAValidEmailAddress<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
            where TProperty : IConvertible
            => ruleBuilder.Must((model, email)
                => email.ToString() != null && PursuitPalEmailValidator.IsValidEmail(email.ToString()!))
            .WithMessage(InvalidZipCodeErrorMessage);

        public static IRuleBuilderOptions<T, TEnum> MustBeValidEnumValue<T, TEnum>(
        this IRuleBuilder<T, TEnum> ruleBuilder)
        where TEnum : struct, Enum
        {
            return (IRuleBuilderOptions<T, TEnum>)ruleBuilder.Custom((value, context) => {
                if (!Enum.IsDefined(typeof(TEnum), value))
                {
                    context.AddFailure("The {PropertyName} must be a valid value of " + typeof(TEnum).Name);
                }
            });
        }
    }
}
