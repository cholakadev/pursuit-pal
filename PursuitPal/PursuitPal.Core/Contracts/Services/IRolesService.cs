using PursuitPal.Core.Responses;

namespace PursuitPal.Core.Contracts.Services
{
    public interface IRolesService
    {
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync();
    }
}
