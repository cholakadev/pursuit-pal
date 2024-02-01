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
            var user = await _usersRepository.AddAsync(request.ToEntity());
            return user.Id;
        }
    }
}
