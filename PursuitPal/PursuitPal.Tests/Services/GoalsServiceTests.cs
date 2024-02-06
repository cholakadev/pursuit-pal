using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.NSubstitute;
using NSubstitute;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Exceptions.ValidationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services;

namespace PursuitPal.Tests.Services
{
    public class GoalsServiceTests
    {
        private GoalsService _sut;
        private IRepository<Goal> _goalsRepository;
        private IUsersContextService _usersContextService;

        public GoalsServiceTests()
        {
            _goalsRepository = Substitute.For<IRepository<Goal>>();
            _usersContextService = Substitute.For<IUsersContextService>();

            _goalsRepository
                .AddAsync(Arg.Any<Goal>())
                .Returns(new Goal
                {
                    Id = Guid.NewGuid(),
                    Details = new GoalDetails
                    {
                        Name = "Test",
                        Description = "Test",
                        CompletionCriteria = "Test",
                    }
                });

            _sut = new GoalsService(_goalsRepository, _usersContextService);
        }

        [Fact]
        public async Task CreateGoal_Handle_WhenGoalIsNotCreatedSuccessfuly_ShouldThrowFailedCreationException()
        {
            _goalsRepository
                .AddAsync(Arg.Any<Goal>())
                .Returns(default(Goal));

            var act = async () => await _sut.CreateGoalAsync(CreateGoalRequest);

            await act.Should().ThrowAsync<CreateUpdateFailedException>();
        }

        [Fact]
        public async Task CreateGoal_Handle_WhenGoalIsCreatedSuccessfuly_ShouldNotThrowFailedCreationException()
        {
            var act = async () => await _sut.CreateGoalAsync(CreateGoalRequest);

            await act.Should().NotThrowAsync();
            await _goalsRepository.Received().AddAsync(Arg.Any<Goal>());
        }

        [Fact]
        public async Task UpdateGoal_Handle_WhenGoalIsNotCreatedSuccessfuly_ShouldThrowFailedCreationException()
        {
            var goals = new List<Goal>()
            {
                new Goal
                {
                    Id = Guid.NewGuid(),
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now,
                    Details = new GoalDetails
                    {
                        Name = "test",
                        Description = "test",
                        CompletionCriteria = "test",
                    },
                },
            };

            var mock = goals.BuildMock();

            _goalsRepository.GetAll().Include(x => x.Details).Returns(mock);

            var act = async () => await _sut.UpdateGoalAsync(UpdateGoalRequest);

            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        private CreateGoalRequest CreateGoalRequest => new CreateGoalRequest
        {
            Name = "name",
            Description = "description",
            CompletionCriteria = "completionCriteria",
            FromDate = DateTime.UtcNow,
            ToDate = DateTime.UtcNow,
            Status = GoalStatus.Active,
        };

        private UpdateGoalRequest UpdateGoalRequest => new UpdateGoalRequest
        {
            Id = Guid.NewGuid(),
            Name = "name",
            FromDate = DateTime.UtcNow,
            ToDate = DateTime.UtcNow,
            Description = "description",
            CompletionCriteria = "completionCriteria",
            Status = GoalStatus.Active,
        };
    }
}
