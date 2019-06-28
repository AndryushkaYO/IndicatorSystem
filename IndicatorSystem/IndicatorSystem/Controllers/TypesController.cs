using IndicatorData;
using IndicatorSystem.Models.Type;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Controllers
{
    public class TypesController:Controller
    {
        static private IIndicatorType _types;
        public TypesController(IIndicatorType types)
        {
            _types = types;
        }

        public IActionResult Index()
        {
            var assetModels = _types.getAll();
            var ListingResult = assetModels
                .Select(result => new TypeListingModel()
                {
                    typeId = result.Id,
                    unit = result.Unit,
                    limit = result.Limit
                });

            var model = new TypeModel()
            {
                Assets = ListingResult
            };

            return View(model);
        }
    
    }
}
