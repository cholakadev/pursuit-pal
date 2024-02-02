namespace PursuitPal.Core.Exceptions.ValidationExceptions
{
    public abstract class ValidationException : BaseException
    {
        protected ValidationException(string message)
            : base(message)
        {
        }
    }
}
