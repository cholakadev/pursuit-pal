namespace PursuitPal.Core.Exceptions.ValidationExceptions
{
    public class InvalidRoleAssignmentException : ValidationException
    {
        public InvalidRoleAssignmentException(string message)
            : base(message)
        {
        }
    }
}
