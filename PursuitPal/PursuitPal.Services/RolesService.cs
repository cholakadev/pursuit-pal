using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Enums;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class RolesService : IRolesService
    {
        private const UserRole SYSADMIN_ROLE = UserRole.SystemAdmin;
        private readonly IRepository<Role> _rolesRepository;
        private readonly IRepository<User> _usersRepository;
        private readonly IUsersContextService _usersContextService;

        public RolesService(
            IRepository<Role> rolesRepository,
            IRepository<User> usersRepository,
            IUsersContextService usersContextService)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _usersContextService = usersContextService ?? throw new ArgumentNullException(nameof(usersContextService));
        }

        public async Task<bool> AssignUserRoleAsync(AssignUserRoleRequest request)
        {
            var isCurrentUserSystemAdmin = _usersContextService.IsInRole(SYSADMIN_ROLE);

            var role = await _rolesRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == request.RoleId);

            if (role is not null &&
                !isCurrentUserSystemAdmin &&
                role.RoleName == SYSADMIN_ROLE.ToString())
                throw new InvalidRoleAssignmentException("Admin users does not have permissions to assign SystemAdmin roles.");

            var users = await _usersRepository.GetAll(true)
                .Where(x => request.UserIds.Contains(x.Id))
                .ToListAsync();

            foreach (var user in users)
            {
                user.RoleId = request.RoleId;
            }

            var updatedUsers = await _usersRepository.UpdateManyAsync(users);

            return updatedUsers.Any();
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync()
            => await _rolesRepository.GetAll()
                .Select(x => x.ToResponse())
                .ToListAsync();
    }
}
