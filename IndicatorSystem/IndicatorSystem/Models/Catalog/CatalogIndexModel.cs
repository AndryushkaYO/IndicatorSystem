using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.Catalog
{
    public class CatalogIndexModel
    {
        public IEnumerable<AssetIndexListingModel> Assets { get; set; }
    }
}
