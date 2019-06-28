using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.User
{
    public class UsersModel
    {
        public  IEnumerable<UsersListingModel> Assets { get; set; }
        public  void sortBy(string value)
        {
            
            if (value == "Email")
            {
                 Assets = Assets.OrderBy(s => s.Email);
            }else if (value == "Name")
            {
                 Assets = Assets.OrderBy(s => s.UsersFullName);
            }
            else if (value == "BirthDate") {
                 Assets = Assets.OrderBy(s => s.UsersBirthDay);
            }
            else{
                 Assets = Assets.OrderBy(s => s.UsersId);
            }
           
        }
    }
}
