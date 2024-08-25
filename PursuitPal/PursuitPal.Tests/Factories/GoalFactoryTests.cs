using FluentAssertions;
using PursuitPal.Core.Enums;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Tests.Factories
{
    public class GoalFactoryTests
    {
        private readonly Goal _goal;
        private readonly CreateGoalRequest _createUpdateGoalRequest;

        public GoalFactoryTests()
        {
            _goal = new Goal
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                Status = GoalStatus.Active,
                Details = new GoalDetails
                {
                    Name = "name",
                    Description = "description",
                    CompletionCriteria = "criteria",
                }
            };

            _createUpdateGoalRequest = new CreateGoalRequest
            {
                Name = "name",
                Description = "description",
                CompletionCriteria = "criteria",
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                Status = GoalStatus.Active,
            };
        }

        [Fact]
        public void Handle_WhenConvertingValidRequestToEntity_ShouldReturnGoalEntity()
        {
            var userId = Guid.NewGuid();
            var entity = _createUpdateGoalRequest.ToEntity(userId);
            entity.Should().BeOfType<Goal>();
            entity.Details.Name.Should().Be(_createUpdateGoalRequest.Name);
            entity.Details.Description.Should().Be(_createUpdateGoalRequest.Description);
            entity.Details.CompletionCriteria.Should().Be(_createUpdateGoalRequest.CompletionCriteria);
            entity.FromDate.Should().Be(_createUpdateGoalRequest.FromDate);
            entity.ToDate.Should().Be(_createUpdateGoalRequest.ToDate);
        }

        [Fact]
        public void Handle_WhenConvertingNullRequestToEntity_ShouldThrowException()
        {
            CreateGoalRequest? request = null;
            Assert.Throws<ArgumentNullException>(() => request.ToEntity(Guid.NewGuid()));
        }

        [Fact]
        public void Handle_WhenConvertingValidEntityToResponse_ShouldReturnResponse()
        {
            var response = _goal.ToResponse();
            response.Should().BeOfType<GoalResponse>();
            response.Name.Should().Be(_goal.Details.Name);
            response.Description.Should().Be(_goal.Details.Description);
            response.CompletionCriteria.Should().Be(_goal.Details.CompletionCriteria);
            response.FromDate.Should().Be(_goal.FromDate);
            response.ToDate.Should().Be(_goal.ToDate);
        }

        [Fact]
        public void Handle_WhenConvertingNullEntityToResponse_ShouldThrowException()
        {
            Goal? goal = null;
            Assert.Throws<ArgumentNullException>(goal.ToResponse);
        }
    }
}
