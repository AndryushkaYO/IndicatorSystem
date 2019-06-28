using IndicatorData;
using IndicatorData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndicatorServices
{
    public class UserService : IUser
    {
        private IndicatorContext _context;

        public UserService(IndicatorContext context)
        {
            _context = context;
        }
        public void Delete(User newItem)
        {
            _context.Remove(newItem);
            _context.SaveChanges();
        }
        public void Add(User newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<User> getAll()
        {
            return _context.Users
                .Include(asset => asset.LoginInfo);
        }

        public DateTime getBirthDate(string Id)
        {
            return _context.Users.FirstOrDefault(asset => asset.Id == Id).BirthDate;
        }

        public User GetById(string ID)
        {
            return _context.Users.FirstOrDefault(asset => asset.Id == ID);
        }

        public string getFullName(string id)
        {
            return _context.Users.FirstOrDefault(asset => asset.Id == id).FullName;
        }       

        public LoginInfo getLoginInfo(string Id)
        {
            return _context.Users.FirstOrDefault(asset => asset.Id == Id).LoginInfo;
        }
    }
}
