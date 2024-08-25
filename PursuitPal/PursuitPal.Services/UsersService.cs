using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Enums;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class UsersService : IUsersService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _usersRepository;
        private readonly IUsersContextService _usersContextService;

        public UsersService(
            IConfiguration configuration,
            IRepository<User> usersRepository,
            IUsersContextService usersContextService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _usersContextService = usersContextService ?? throw new ArgumentNullException(nameof(usersContextService));
        }

        public async Task<UserTokenResponse> GenerateUserTokenAsync(GenerateUserTokenRequest request)
        {
            var user = await _usersRepository.GetAll()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
                throw new FailedAuthenticationException();

            var pursuitPalHash = new PursuitPalHash();
            var passwordMatch = pursuitPalHash
                .VerifyPassword(request.Password, user.Password, user.Salt);

            if (!passwordMatch)
                throw new FailedAuthenticationException();

            var jwtGenerator = new JwtGenerator(_configuration);
            var token = jwtGenerator.GenerateToken(user.ToModel());

            return new UserTokenResponse { Token = token };
        }

        public async Task<bool> ManageDirectReportsAsync(ManageDirectReportsRequest request)
        {
            var usersToUpdate = await _usersRepository.GetAll()
                .Where(x => request.UserIds.Contains(x.Id))
                .ToListAsync();

            
            var reportsToId = request.ReportsToUserId.HasValue && _usersContextService.IsInRole(UserRole.Admin)
                ? request.ReportsToUserId.Value
                : _usersContextService.UserId;

            usersToUpdate.ForEach(x => x.ReportsTo = reportsToId);

            var updatedUsers = await _usersRepository.UpdateManyAsync(usersToUpdate);

            return updatedUsers.Any();
        }

        public async Task<Guid> RegisterUserAsync(CreateUpdateUserRequest request)
        {
            var pursuitPalHash = new PursuitPalHash();
            var passwordHash = pursuitPalHash.HashPasword(request.Password, out var salt);
            var hexStringSalt = Convert.ToHexString(salt);

            var userToCreate = request.ToEntity(passwordHash, hexStringSalt);

            var createdUser = await _usersRepository.AddAsync(userToCreate);

            if (createdUser is null)
                throw new CreateUpdateFailedException(nameof(RegisterUserAsync));

            return createdUser.Id;
        }
    }
}
