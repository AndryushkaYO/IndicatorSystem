using IndicatorData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Models.Catalog
{
    public class InfographicsData
    {
        public List<KeyValuePair<IndicatorPerson, int>> workersGreat;
        public List<KeyValuePair<IndicatorPerson, int>> workersSmall;
        public List<KeyValuePair<IndicatorPerson, int>> workersAll;
        public double averWorkersIndex;
        public double averWater;
        public double averGas;
        public double averElectricity;
        public List<KeyValuePair<string, int>> userGasGreat;
        public List<KeyValuePair<string, int>> userGasSmall;
        public List<KeyValuePair<string, int>> userWaterGreat;
        public List<KeyValuePair<string, int>> userWaterSmall;
        public List<KeyValuePair<string, int>> userElectricityGreat;
        public List<KeyValuePair<string, int>> userElectricitySmall;
        public List<KeyValuePair<string, int>> userWaterAll;
        public List<KeyValuePair<string, int>> userGasAll;
        public List<KeyValuePair<string, int>> userElectricityAll;
        public List<KeyValuePair<string, double[]>> chartList;
    }
}
