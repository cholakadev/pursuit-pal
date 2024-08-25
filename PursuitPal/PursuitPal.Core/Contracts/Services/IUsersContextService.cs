using PursuitPal.Core.Enums;

namespace PursuitPal.Core.Contracts.Services
{
    public interface IUsersContextService
    {
        Guid UserId { get; }

        IEnumerable<UserRole>? Roles { get; }

        bool IsInRole(UserRole role);
    }
}
