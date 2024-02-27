using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class RolesService : IRolesService
    {
        private const string SYSADMIN_ROLE = "SystemAdmin";
        private readonly IRepository<Role> _rolesRepository;
        private readonly IUsersContextService _usersContextService;

        public RolesService(
            IRepository<Role> rolesRepository,
            IUsersContextService usersContextService)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _usersContextService = usersContextService ?? throw new ArgumentNullException(nameof(usersContextService));
        }

        public async Task<bool> AssignUserRoleAsync(AssignUserRoleRequest request)
        {
            //var isCurrentUserSystemAdmin = _usersContextService.IsInRole(SYSADMIN_ROLE);

            //var role = await _rolesRepository.GetAll()
            //    .FirstOrDefaultAsync(x => x.Id == request.RoleId);

            //if (role is not null &&
            //    !isCurrentUserSystemAdmin &&
            //    role.RoleName == SYSADMIN_ROLE)
            //{
            //    throw new InvalidRoleAssignmentException("Admin users does not have right to assign SystemAdmin roles.");
            //}

            //var userRoles = new List<UserRoles>();

            //foreach (var userId in request.UserIds)
            //{
            //    userRoles.Add(new UserRoles
            //    {
            //        RoleId = request.RoleId,
            //        UserId = userId,
            //    });
            //}

            //// Needs to update user role if the user already has one

            //var createdUserRoles = await _userRolesRepository.UpdateManyAsync(userRoles);

            return true;
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync()
            => await _rolesRepository.GetAll()
                .Select(x => x.ToResponse())
                .ToListAsync();
    }
}
