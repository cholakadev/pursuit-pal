using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;

namespace PursuitPal.Core.Services
{
    public interface IUsersService
    {
        Task<Guid> RegisterUserAsync(CreateUpdateUserRequest request);

        Task<UserTokenResponse> GenerateUserTokenAsync(GenerateUserTokenRequest request);
    }
}
