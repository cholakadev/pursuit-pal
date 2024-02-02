using Microsoft.AspNetCore.Http;
using PursuitPal.Core.Services;

namespace PursuitPal.Services
{
    public class UsersContextService : IUsersContextService
    {
        private readonly HttpContext? _context;

        public UsersContextService(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public Guid UserId => Guid.TryParse(
            _context?.User?.Claims.SingleOrDefault(x => x.Type == "Id")?.Value,out var parsedGuid)
                ? parsedGuid
                : Guid.Empty;
    }
}
