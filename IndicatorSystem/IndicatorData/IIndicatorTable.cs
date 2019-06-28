using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData
{
    public interface IIndicatorTable
    {
        IEnumerable<IndicatorTable> getAll();
        IndicatorTable GetById(int ID);
        void Add(IndicatorTable newElem);
        int getAmount(int Id);
        DateTime getDate(int Id);
        User getUser(int Id);
        IndicatorPerson getWorker(int id);
        LoginInfo getUsersLogInfo(int id);

    }
}
