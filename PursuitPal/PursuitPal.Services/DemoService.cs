using Bogus;
using Microsoft.Extensions.Configuration;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Enums;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services
{
    public class DemoService : IDemoService
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Goal> _goalsRepository;
        private readonly IRepository<GoalDetails> _goalDetailsRepository;
        private readonly IConfiguration _configuration;

        public DemoService(
            IRepository<User> usersRepository,
            IRepository<Goal> goalsRepository,
            IRepository<GoalDetails> goalDetailsRepository,
            IConfiguration configuration)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _goalsRepository = goalsRepository ?? throw new ArgumentNullException(nameof(goalsRepository));
            _goalDetailsRepository = goalDetailsRepository ?? throw new ArgumentNullException(nameof(goalDetailsRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> SeedDataAsync(SeedDemoDataRequest request)
        {
            var createdUsers = await GenerateFakeUsers(request.NumberOfUsers);
            var createdGoals = await GenerateFakeGoals(createdUsers.ToList(), request.NumberOfGoalsPerUser);
            var createdGoalDetails = await GenerateFakeGoalDetails(createdGoals.ToList());

            var hasAnyFakeData = createdUsers != null && createdUsers.Any()
                && createdGoals != null && createdGoals.Any()
                && createdGoalDetails != null && createdGoalDetails.Any();

            return hasAnyFakeData;
        }

        private async Task<IEnumerable<User>> GenerateFakeUsers(int numberOfUsers)
        {
            var pursuitPalHash = new PursuitPalHash();
            var demoPassword = _configuration.GetSection("Secrets:DemoPassword").Value;
            var fakePasswordHash = pursuitPalHash.HashPasword(demoPassword, out byte[] salt);
            var fakeSaltString = Convert.ToHexString(salt);

            var userFaker = new Faker<User>()
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Position, f => f.Name.JobTitle())
                .RuleFor(x => x.DepartmentId, f => f.Random.Number(1, 16))
                .RuleFor(x => x.Password, f => fakePasswordHash)
                .RuleFor(x => x.Salt, f => fakeSaltString);

            var generatedUsers = userFaker.Generate(numberOfUsers);
            var createdUsers = await _usersRepository.AddManyAsync(generatedUsers);

            return createdUsers;
        }

        private async Task<IEnumerable<Goal>> GenerateFakeGoals(List<User> createdUsers, int numberOfGoalsPerUser)
        {
            var faker = new Faker();

            var goals = new List<Goal>();
            foreach (var createdUser in createdUsers)
            {
                for (int i = 0; i < numberOfGoalsPerUser; i++)
                {
                    var fromDate = faker.Date.Between(DateTime.Now, DateTime.Now.AddMonths(1));
                    var toDate = faker.Date.Between(fromDate.AddMonths(1), fromDate.AddMonths(6));
                    var randomStatus = faker.Random.Enum<GoalStatus>();

                    var goalFaker = new Faker<Goal>()
                        .RuleFor(x => x.UserId, f => createdUser.Id)
                        .RuleFor(x => x.FromDate, f => fromDate)
                        .RuleFor(x => x.ToDate, f => toDate)
                        .RuleFor(x => x.Status, randomStatus.ToStringStatus());

                    var generatedGoals = goalFaker.Generate(1);
                    goals.Add(generatedGoals.First());
                }
            }

            var createdGoals = await _goalsRepository.AddManyAsync(goals);

            return createdGoals;
        }

        private async Task<IEnumerable<GoalDetails>> GenerateFakeGoalDetails(List<Goal> createdGoals)
        {
            var goalDetails = new List<GoalDetails>();
            foreach (var createdGoal in createdGoals)
            {
                var goalDetailsFaker = new Faker<GoalDetails>()
                    .RuleFor(x => x.GoalId, f => createdGoal.Id)
                    .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                    .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(x => x.CompletionCriteria, f => f.Hacker.Phrase());

                var generatedGoalDetails = goalDetailsFaker.Generate(1);
                goalDetails.Add(generatedGoalDetails.First());
            }

            var createdGoalDetails = await _goalDetailsRepository.AddManyAsync(goalDetails);

            return createdGoalDetails;
        }
    }
}
