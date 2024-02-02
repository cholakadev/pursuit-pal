using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Repositories;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Services;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> _usersRepository;

        public UsersService(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<Guid> RegisterUserAsync(CreateUpdateUserRequest request)
        {
            var purshutPalHash = new PursuitPalHash();
            var passwordHash = purshutPalHash.HashPasword(request.Password, out var salt);
            var hexStringSalt = Convert.ToHexString(salt);

            var userToCreate = request.ToEntity(passwordHash, hexStringSalt);

            var createdUser = await _usersRepository.AddAsync(userToCreate);

            if (createdUser is null)
            {
                throw new FailedCreationException(nameof(RegisterUserAsync));
            }

            return createdUser.Id;
        }
    }
}
