﻿using Microsoft.Extensions.Configuration;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Repositories;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Core.Services;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IConfiguration _configuration;

        public UsersService(IRepository<User> usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<UserTokenResponse> GenerateUserTokenAsync(GenerateUserTokenRequest request)
        {
            var user = await _usersRepository.FindAsync(x => x.Email == request.Email);

            if (user == null)
            {
                throw new FailedAuthenticationException();
            }

            var pursuitPalHash = new PursuitPalHash();
            var passwordMatch = pursuitPalHash
                .VerifyPassword(request.Password, user.Password, user.Salt);

            if (!passwordMatch)
            {
                throw new FailedAuthenticationException();
            }

            var jwtGenerator = new JwtGenerator(_configuration);
            var token = jwtGenerator.GenerateToken(user.ToModel());

            return new UserTokenResponse { Token = token };
        }

        public async Task<Guid> RegisterUserAsync(CreateUpdateUserRequest request)
        {
            var pursuitPalHash = new PursuitPalHash();
            var passwordHash = pursuitPalHash.HashPasword(request.Password, out var salt);
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