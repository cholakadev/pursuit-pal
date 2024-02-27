using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;

namespace PursuitPal.Core.Contracts.Services
{
    public interface IRolesService
    {
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync();

        Task<bool> AssignUserRoleAsync(AssignUserRoleRequest request);
    }
}
