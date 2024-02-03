using PursuitPal.Core.Requests;

namespace PursuitPal.Core.Contracts.Services
{
    public interface IDemoService
    {
        Task<bool> SeedDataAsync(SeedDemoDataRequest request);
    }
}
