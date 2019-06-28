using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.Worker
{
    public class WorkerModel
    {
        public IEnumerable<WorkerListingModel> Assets { get; set; }
    }
}
