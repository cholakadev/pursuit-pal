using Microsoft.Extensions.Logging;

namespace PursuitPal.Core.Exceptions.OperationExceptions
{
    public class CreateUpdateFailedException : BaseException
    {
        public CreateUpdateFailedException(string method)
            : base($"{method} failed to create/update an entity.")
        {
        }
    }
}
