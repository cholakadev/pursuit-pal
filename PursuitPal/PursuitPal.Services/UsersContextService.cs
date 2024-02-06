using Microsoft.AspNetCore.Http;
using PursuitPal.Core.Contracts.Services;
using System.Security.Claims;

namespace PursuitPal.Services
{
    public class UsersContextService : IUsersContextService
    {
        private readonly HttpContext? _context;

        public UsersContextService(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor?.HttpContext;
        }

        public Guid UserId => Guid.TryParse(
            _context?.User?.Claims.SingleOrDefault(x => x.Type == "Id")?.Value,out var parsedGuid)
                ? parsedGuid
                : Guid.Empty;

        public IEnumerable<string>? Roles => _context?.User?.Claims
            .Where(x => x.Type == ClaimTypes.Role)
            .Select(x => x.Value);

        public bool IsInRole(string role)
            => Roles?.Any(r => r.Contains(role)) == true;
    }
}
