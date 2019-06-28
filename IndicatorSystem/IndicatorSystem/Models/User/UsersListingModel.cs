using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.User
{
    public class UsersListingModel
    {
        public string UsersId { get; set; }
        public string UsersFullName { get; set; }
        public DateTime UsersBirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
