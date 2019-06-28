using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.Worker
{
    public class WorkerListingModel
    {
        public int typeId { get; set; }
        public string unit { get; set; }
        public int limit { get; set; }
        public string workerFullName { get; set; }
        public string workerPhone { get; set; }
    }
}
