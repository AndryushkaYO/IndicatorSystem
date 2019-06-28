using IndicatorData;
using IndicatorData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndicatorServices
{
    public class IndicatorTableService : IIndicatorTable
    {
        private IndicatorContext _context;

        public IndicatorTableService(IndicatorContext context)
        {
            _context = context;
        }

        public void Add(IndicatorTable newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<IndicatorTable> getAll()
        {
            return _context.IndicatorTable
                .Include(asset => asset.user)
                .Include(asset => asset.user.LoginInfo)
                .Include(asset => asset.worker.type)
                .Include(asset => asset.worker);
        }

        public int getAmount(int Id)
        {
            return _context.IndicatorTable
               .FirstOrDefault(asset => asset.Id == Id).amount;
        }

        public IndicatorTable GetById(int ID)
        {
            return _context.IndicatorTable
                .Include(asset => asset.user)
                .Include(asset => asset.worker.type)
                .Include(asset => asset.worker)
                .Include(asset => asset.user.LoginInfo)
                .FirstOrDefault(asset => asset.Id == ID);
        }

        public DateTime getDate(int Id)
        {
            return _context.IndicatorTable
                .FirstOrDefault(asset => asset.Id == Id).date;
        }

        
        public User getUser(int Id)
        {
            return GetById(Id).user;
        }

        public LoginInfo getUsersLogInfo(int id)
        {
            return GetById(id).user.LoginInfo;
        }

        public IndicatorPerson getWorker(int id)
        {
            return GetById(id).worker;
        }
    }
}
