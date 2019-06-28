using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndicatorData.Models
{
    public class IndicatorPerson
    {
        [Key]
        public string MobilePhone { get; set; }

        public string FullName { get; set; }
        public IndicatorType type { get; set; }
    }
}
