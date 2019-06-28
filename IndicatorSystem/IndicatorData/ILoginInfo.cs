using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorData
{
    public interface ILoginInfo
    {
        IEnumerable<LoginInfo> getAll();
        LoginInfo GetByEmail(string Email);
        void Add(LoginInfo newElem);       
        string getPassword(string Email);
         void Delete(LoginInfo newItem);
        
    }
}
