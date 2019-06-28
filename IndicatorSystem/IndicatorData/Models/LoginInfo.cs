using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndicatorData.Models
{
    public class LoginInfo
    {
        [Key]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
