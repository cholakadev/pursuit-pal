using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class UserFactory
    {
        public static User ToEntity(
            this CreateUpdateUserRequest request,
            string? password,
            string? salt)
            => new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = password ?? throw new ArgumentNullException(nameof(password)),
                Salt = salt ?? throw new ArgumentNullException(nameof(salt)),
            };
    }
}
