using PursuitPal.Core.Requests;

namespace PursuitPal.Core.Services
{
    public interface IDemoService
    {
        Task<bool> SeedDataAsync(SeedDemoDataRequest request);
    }
}
