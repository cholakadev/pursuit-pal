namespace PursuitPal.Core.Exceptions.ValidationExceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
