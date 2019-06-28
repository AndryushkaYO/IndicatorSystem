using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.Catalog
{
    public class AssetIndexListingModel
    {
        /*
         IndicatorTable.Id , Users.Id, Users.FullName, BirthDate, Email, Password, 
         IndicatorTypes.Id, Unit, Limit, amount, date, IndicatorPersons.FullName, MobilePhone  
        */
        public int Id { get; set; }
        public  string UsersId { get; set; }
        public string UsersFullName { get; set; }
        public DateTime UsersBirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int typeId { get; set; }
        public string unit { get; set; }
        public int limit { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }
        public string workerFullName { get; set; }
        public string workerPhone { get; set; }
    }
}
