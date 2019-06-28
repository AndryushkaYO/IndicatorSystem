using IndicatorData;
using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndicatorServices
{
    public class LoginInfoService : ILoginInfo
    {
        private IndicatorContext _context;

        public LoginInfoService(IndicatorContext context)
        {
            _context = context;
        }
        public void Delete(LoginInfo newItem)
        {
            _context.Remove(newItem);
            _context.SaveChanges();
        }
        public void Add(LoginInfo newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<LoginInfo> getAll()
        {
            return _context.LoginInfos;
        }

        public LoginInfo GetByEmail(string Email)
        {
            return _context.LoginInfos.FirstOrDefault(asset => asset.Email == Email);
        }        

        public string getPassword(string Email)
        {
            return _context.LoginInfos.FirstOrDefault(asset => asset.Email == Email).Password;
        }
    }
}
