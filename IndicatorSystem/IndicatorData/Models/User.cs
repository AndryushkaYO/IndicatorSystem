using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName {get; set;}
        public DateTime BirthDate { get; set; }
        public LoginInfo  LoginInfo { get; set; }
    }
}
