using PursuitPal.Core.Contracts;

namespace PursuitPal.Core.Requests
{
    public class CreateUpdateUserRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
