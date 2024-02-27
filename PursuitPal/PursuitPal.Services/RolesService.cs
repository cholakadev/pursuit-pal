using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRepository<Role> _rolesRepository;

        public RolesService(IRepository<Role> rolesRepository)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync()
            => await _rolesRepository.GetAll()
                .Select(x => x.ToResponse())
                .ToListAsync();
    }
}
