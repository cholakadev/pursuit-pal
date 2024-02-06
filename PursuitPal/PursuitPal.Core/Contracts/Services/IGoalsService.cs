using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;

namespace PursuitPal.Core.Contracts.Services
{
    public interface IGoalsService
    {
        Task<GoalResponse> CreateGoalAsync(CreateGoalRequest request);

        Task<GoalResponse> UpdateGoalAsync(UpdateGoalRequest request);

        Task<IEnumerable<GoalResponse>> GetAllGoalsAsync(GetGoalsRequest request);
    }
}
