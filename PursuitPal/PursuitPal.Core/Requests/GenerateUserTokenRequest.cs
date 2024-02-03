using PursuitPal.Core.Contracts;

namespace PursuitPal.Core.Requests
{
    public class GenerateUserTokenRequest : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
