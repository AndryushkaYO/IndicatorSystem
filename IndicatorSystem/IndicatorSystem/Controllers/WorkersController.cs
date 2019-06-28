using IndicatorData;
using IndicatorSystem.Models.Worker;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Controllers
{
    public class WorkersController:Controller
    {
        static private IIndicatorPerson _workers;
        public WorkersController(IIndicatorPerson worker)
        {
            _workers = worker;
        }

        public IActionResult Index()
        {
            var assetModels = _workers.getAll();
            var ListingResult = assetModels
                .Select(result => new WorkerListingModel()
                {
                    workerFullName= result.FullName,
                    workerPhone = result.MobilePhone,
                    typeId = result.type.Id,
                    unit = result.type.Unit,
                    limit = result.type.Limit
                });

            var model = new WorkerModel()
            {
                Assets = ListingResult
            };

            return View(model);
        }
    }
}
