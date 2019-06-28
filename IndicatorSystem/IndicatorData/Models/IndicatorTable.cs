using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData.Models
{
    public class IndicatorTable
    {
        public int Id { get; set; }
        public User user { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }
        public IndicatorPerson worker { get; set; }
    }
}
