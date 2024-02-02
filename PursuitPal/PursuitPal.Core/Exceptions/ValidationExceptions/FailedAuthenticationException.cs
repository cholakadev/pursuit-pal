namespace PursuitPal.Core.Exceptions.ValidationExceptions
{
    public class FailedAuthenticationException : ValidationException
    {
        public FailedAuthenticationException()
            : base("Authentication failed.")
        {
        }
    }
}
