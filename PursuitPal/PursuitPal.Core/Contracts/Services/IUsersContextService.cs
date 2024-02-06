namespace PursuitPal.Core.Contracts.Services
{
    public interface IUsersContextService
    {
        Guid UserId { get; }

        IEnumerable<string>? Roles { get; }

        bool IsInRole(string role);
    }
}
