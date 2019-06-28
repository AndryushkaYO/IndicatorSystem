using IndicatorData;
using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndicatorServices
{
    public class IndicatorTypeService: IIndicatorType
    {
        private IndicatorContext _context;

        public IndicatorTypeService(IndicatorContext context)
        {
            _context = context;
        }

        public void Add(IndicatorType newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<IndicatorType> getAll()
        {
            return _context.IndicatorTypes;
        }

        public IndicatorType GetById(int ID)
        {
            return _context.IndicatorTypes.FirstOrDefault(asset => asset.Id == ID);
        }
               

        public int getLimit(int id)
        {
            return _context.IndicatorTypes.FirstOrDefault(asset => asset.Id == id).Limit;
        }
        public void Delete(IndicatorType newItem)
        {
            _context.Remove(newItem);
            _context.SaveChanges();
        }
        public string getUnit(int id)
        {
            return _context.IndicatorTypes.FirstOrDefault(asset => asset.Id == id).Unit;
        }
    }
}
