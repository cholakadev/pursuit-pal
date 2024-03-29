﻿namespace PursuitPal.Core.Requests
{
    public class CreateUpdateUserRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public int DepartmentId { get; set; }

        public string Password { get; set; }
    }
}
