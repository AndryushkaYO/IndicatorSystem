using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData
{
    public interface IUser
    {
        IEnumerable<User> getAll();
        User GetById(string ID);
        void Add(User newElem);       
        DateTime getBirthDate(string Id);
        string getFullName(string id);
        LoginInfo getLoginInfo(string Id);
        void Delete(User newItem);
        
    }
}
