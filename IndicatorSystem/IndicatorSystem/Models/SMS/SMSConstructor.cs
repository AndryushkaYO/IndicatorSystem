using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.SMS
{
    public class SMSConstructor
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string id { get;  set; }
        public int value;
        public SMSConstructor() {  }
        public SMSConstructor(DateTime d, string na, string nu, string id_, int i)
        {           
            date = d;
            name = na;
            number = nu;
            id = id_;
            value = i;
        }
    }
}
