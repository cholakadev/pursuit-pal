using Microsoft.Extensions.Logging;

namespace PursuitPal.Core.Exceptions
{
    public class FailedCreationException : BaseException
    {
        public FailedCreationException(string method)
            : base($"{method} failed to create an entity.")
        {
        }
    }
}
