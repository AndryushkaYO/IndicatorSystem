using IndicatorData;
using IndicatorData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndicatorServices
{
    public class IndicatorPersonService : IIndicatorPerson
    {
        private IndicatorContext _context;

        public IndicatorPersonService(IndicatorContext context)
        {
            _context = context;
        }

        public void Add(IndicatorPerson newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<IndicatorPerson> getAll()
        {
            return _context.IndicatorPersons
                .Include(asset => asset.type); 
        }
        public void Delete(IndicatorPerson newItem)
        {
            _context.Remove(newItem);
            _context.SaveChanges();
        }
        public IndicatorPerson GetByPhone(string Phone)
        {
            return _context.IndicatorPersons.FirstOrDefault(asset => asset.MobilePhone == Phone);
        }

        public string getFullName(string Phone)
        {
            return _context.IndicatorPersons.FirstOrDefault(asset => asset.MobilePhone == Phone).FullName;
        }

        public string getMobilePhone(string Phone)
        {
            return _context.IndicatorPersons.FirstOrDefault(asset => asset.MobilePhone == Phone).MobilePhone;
        }

        public IndicatorType getType(string Phone)
        {
            return _context.IndicatorPersons.FirstOrDefault(asset => asset.MobilePhone == Phone).type;
        }
    }
}
