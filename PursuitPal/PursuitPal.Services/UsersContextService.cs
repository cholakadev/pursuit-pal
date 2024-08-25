using Microsoft.AspNetCore.Http;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Enums;
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

        public IEnumerable<UserRole>? Roles => _context?.User?.Claims
            .Where(x => x.Type == ClaimTypes.Role)
            .Select(x => (UserRole)Enum.Parse(typeof(UserRole), x.Value));

        public bool IsInRole(UserRole role)
            => Roles?.Contains(role) == true;
    }
}
