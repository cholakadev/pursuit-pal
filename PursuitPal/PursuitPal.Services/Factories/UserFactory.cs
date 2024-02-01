using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class UserFactory
    {
        public static User ToEntity(this CreateUpdateUserRequest request)
            => new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };
    }
}
