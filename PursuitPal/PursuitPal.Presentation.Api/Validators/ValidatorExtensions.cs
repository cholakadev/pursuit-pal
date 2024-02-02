using FluentValidation;
using PursuitPal.Core.Helpers;
using System.Text.RegularExpressions;

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
    }
}
