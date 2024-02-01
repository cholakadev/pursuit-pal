using PursuitPal.Core.Requests;

namespace PursuitPal.Core.Services
{
    public interface IUsersService
    {
        Task<Guid> RegisterUserAsync(CreateUpdateUserRequest request);
    }
}
