using PursuitPal.Core.Contracts;

namespace PursuitPal.Core.Responses
{
    public class UserTokenResponse : IResponse
    {
        public string Token { get; set; }
    }
}
