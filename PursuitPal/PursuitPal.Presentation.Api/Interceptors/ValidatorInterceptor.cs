using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ValidationException = PursuitPal.Core.Exceptions.ValidationExceptions.ValidationException;

namespace PursuitPal.Presentation.Api.Interceptors
{
    public class ValidatorInterceptor : IValidatorInterceptor
    {
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (!result.IsValid)
            {
                var error = result.Errors.First();
                throw new ValidationException(error.ErrorMessage);
            }

            return result;
        }
    }
}
