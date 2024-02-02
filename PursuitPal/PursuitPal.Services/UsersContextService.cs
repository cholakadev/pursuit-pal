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

        public Guid UserId => Guid.Parse(_context!.Items["Id"].ToString());
    }
}
