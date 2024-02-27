using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class RoleFactory
    {
        public static RoleResponse ToResponse(this Role entity)
            => entity is null
            ? throw new ArgumentNullException(nameof(entity))
            : new RoleResponse
            {
                Id = entity.Id,
                Name = entity.RoleName,
            };
    }
}
