using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData
{
    public interface IIndicatorPerson
    {
        IEnumerable<IndicatorPerson> getAll();
        IndicatorPerson GetByPhone(string Phone);
        void Add(IndicatorPerson newElem);
        string getFullName(string Phone);
        string getMobilePhone(string Phone);
        IndicatorType getType(string Phone);
        void Delete(IndicatorPerson newItem);
    }
}
