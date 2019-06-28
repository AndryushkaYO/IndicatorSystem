using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData
{
    public interface IIndicatorType
    {
        IEnumerable<IndicatorType> getAll();
        IndicatorType GetById(int ID);
        void Add(IndicatorType newElem);       
        string getUnit(int id);
        int getLimit(int id);
        void Delete(IndicatorType newItem);
    }
}
