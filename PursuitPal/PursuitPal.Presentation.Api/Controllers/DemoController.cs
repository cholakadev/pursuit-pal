using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Services;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class DemoController : Controller
    {
        private readonly IDemoService _demoService;

        public DemoController(IDemoService demoService)
        {
            _demoService = demoService ?? throw new ArgumentNullException(nameof(demoService));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // TODO: Add authorization policy so it can be done only by system admins and disable this endpoint on prod.
        public async Task<IActionResult> SeedDataAsync(SeedDemoDataRequest request)
            => Ok(await _demoService.SeedDataAsync(request));
    }
}
