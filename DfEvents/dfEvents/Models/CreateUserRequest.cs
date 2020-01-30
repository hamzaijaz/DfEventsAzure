using System;
using System.Collections.Generic;
using System.Text;

namespace dfEvents.Models
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
