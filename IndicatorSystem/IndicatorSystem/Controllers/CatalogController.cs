using IndicatorData;
using IndicatorData.Models;
using IndicatorSystem.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Controllers
{
    public class CatalogController : Controller
    {
        static private IIndicatorTable _assets;
        static private IUser _users;
        static private IIndicatorPerson _workers;
        static private IIndicatorType _types;
        public CatalogController(IIndicatorTable asset, IUser user, IIndicatorPerson worker, IIndicatorType types)
        {
            _assets = asset;
            _users = user;
            _workers = worker;
            _types = types;
        }
        /*
        public IActionResult Infographics()
        {

            var assetModels = _assets.getAll();
            var ListingResult = assetModels
                .Select(result => new AssetIndexListingModel()
                {
                    Id = result.Id,
                    UsersId = result.user.Id,
                    UsersFullName = result.user.FullName,
                    UsersBirthDay = result.user.BirthDate,
                    // Email = result.user.LoginInfo.Email,
                    //Password = result.user.LoginInfo.Password,
                    typeId = result.worker.type.Id,
                    unit = result.worker.type.Unit,
                    limit = result.worker.type.Limit,
                    amount = result.amount,
                    date = result.date,
                    workerFullName = result.worker.FullName,
                    workerPhone = result.worker.MobilePhone
                });

            var model = new CatalogIndexModel()
            {
                Assets = ListingResult
            };
            return View(model);
        }
        */
        public IActionResult InfographicsPartial(string value)
        {
            string[] arr = value.Split('*');
            
            DateTime from;
            DateTime to;
            if (arr[0] == "")
            {
                 from = new DateTime(2019, 3,9, 10,0,0);
            }
            else
            {
                string[] date1 = arr[0].Split('-');
                from = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));

            }
            if (arr[1] == "")
            {
                to = DateTime.Today;
            }
            else
            {
                string[] date1 = arr[1].Split('-');
                to = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));
            }
            
            
            int stry1 = to.Day + DateTime.DaysInMonth(from.Year, from.Month)-from.Day;
            TimeSpan try2 = to - from;
            var asset = _assets.getAll();
            List<IndicatorTable> assetModels = new List<IndicatorTable>();
            if(arr[2] != "Name")
            {
                foreach (var i in asset)
                {
                    if (i.date <= to && i.date >= from && i.user.FullName == arr[2])
                    {
                        assetModels.Add(i);
                    }
                }
            }
            else if(arr[3] != "Name")
            {
                foreach (var i in asset)
                {
                    if (i.date <= to && i.date >= from && i.worker.FullName == arr[3])
                    {
                        assetModels.Add(i);
                    }
                }
            }
            else
            {
                foreach(var i in asset)
                {
                    if(i.date<=to && i.date >= from)
                    {
                        assetModels.Add(i);
                    }
                }
            }
            int p = 0;
            List<KeyValuePair<string, double[]>> chartList = new List<KeyValuePair<string, double[]>>();
            
            for (int az = 0; az < 5; az++)
            {
                DateTime try3 = from + (try2 / 5) * p++;
                DateTime try4 = from + (try2 / 5) * p;
                double[] inArr = new double[3];
                foreach (var i in assetModels)
                {
                    if (i.date <= try4 && i.date >= try3)
                    {
                        if (i.worker.type.Id == 1)
                        {
                            inArr[0] += i.amount;
                        }else if(i.worker.type.Id == 2)
                        {
                            inArr[1] += i.amount;
                        }
                        else
                        {
                            inArr[2] += i.amount;
                        }
                    }
                }
                string str = try3.Date.ToShortDateString() + '-' + try4.Date.ToShortDateString();
                KeyValuePair<string, double[]> w = new KeyValuePair<string, double[]>(str, inArr);                
                chartList.Add(w);
            }
            Dictionary<IndicatorPerson, int> workersWithIndexAmount= new Dictionary<IndicatorPerson, int>();
            Dictionary<User, int> waterUsers = new Dictionary<User, int>();
            Dictionary<User, int> gasUsers = new Dictionary<User, int>();
            Dictionary<User, int> elUsers = new Dictionary<User, int>();
            double aw=0, ae=0, ag=0;
            int counterG = 0, counterE = 0, counterW = 0, counter = 0 ;
            
            foreach(var item in assetModels)
            {
                counter++;
                if (item.worker.type.Id == 1)
                {
                    ag += item.amount;
                    counterG++;
                    gasUsers[item.user] = 0;
                }
                else if(item.worker.type.Id == 2)
                {
                    ae += item.amount;
                    counterE++;
                    elUsers[item.user] = 0;
                }
                else if(item.worker.type.Id == 3)
                {
                    aw += item.amount;
                    counterW++;

                    waterUsers[item.user] = 0;
                }
                workersWithIndexAmount[item.worker]=0;
                
            }
            foreach (var item in assetModels)
            {
                if (item.worker.type.Id == 1)
                {
                    gasUsers[item.user] += item.amount;
                }
                else if (item.worker.type.Id == 2)
                {
                    elUsers[item.user] += item.amount;
                }
                else if (item.worker.type.Id == 3)
                {
                    waterUsers[item.user] += item.amount;
                }
                workersWithIndexAmount[item.worker]++;                
            }
            int k = 0, ki=0;
            List<KeyValuePair<IndicatorPerson, int>> workersSorted = new List<KeyValuePair<IndicatorPerson, int>>();
            foreach (var item in workersWithIndexAmount)
            {
                ki++;
                workersSorted.Add(new KeyValuePair<IndicatorPerson,int>(item.Key, item.Value));
            }
            workersSorted = (from i in workersSorted orderby i.Value descending select i).ToList();
            KeyValuePair<IndicatorPerson, int> a = workersSorted[0];
            KeyValuePair<IndicatorPerson, int> b = workersSorted[ki-1];
            List<KeyValuePair<IndicatorPerson, int>> workersGreatest = new List<KeyValuePair<IndicatorPerson, int>>();
            List<KeyValuePair<IndicatorPerson, int>> workersSmallest = new List<KeyValuePair<IndicatorPerson, int>>();
            foreach (var item in workersSorted)
            {
                if (item.Value == a.Value)
                {                    
                    workersGreatest.Add(item);
                }
                if (item.Value == b.Value)
                {
                    workersSmallest.Add(item);
                }               
            }
            k = 0;
            List<KeyValuePair<string, int>> sortedWaterUsers = new List<KeyValuePair<string, int>>();            
            foreach (var item in waterUsers)
            {
                k++;
                sortedWaterUsers.Add(new KeyValuePair<string, int>(item.Key.FullName, item.Value));
            }
            sortedWaterUsers = (from i in sortedWaterUsers orderby i.Value descending select i).ToList();
            List<KeyValuePair<string, int>> sortedWaterUsersG = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> sortedWaterUsersS = new List<KeyValuePair<string, int>>();
            KeyValuePair<string, int> c = sortedWaterUsers[0];
            KeyValuePair<string, int> d = sortedWaterUsers[k - 1];
            foreach (var item in sortedWaterUsers)
            {
                if (item.Value == c.Value)
                {
                    sortedWaterUsersG.Add(item);
                }
                if (item.Value == d.Value)
                {
                    sortedWaterUsersS.Add(item);
                }
            }
            k = 0;
            List<KeyValuePair<string, int>> sortedGasUsers = new List<KeyValuePair<string, int>>();
            foreach (var item in gasUsers)
            {
                k++;
                sortedGasUsers.Add(new KeyValuePair<string, int>(item.Key.FullName, item.Value));
            }
            sortedGasUsers = (from i in sortedGasUsers orderby i.Value descending select i).ToList();
            List<KeyValuePair<string, int>> sortedGasUsersG = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> sortedGasUsersS = new List<KeyValuePair<string, int>>();
            KeyValuePair<string, int> e = sortedGasUsers[0];
            KeyValuePair<string, int> f = sortedGasUsers[k - 1];
            foreach (var item in sortedGasUsers)
            {
                if (item.Value == e.Value)
                {
                    sortedGasUsersG.Add(item);
                }
                if (item.Value == f.Value)
                {
                    sortedGasUsersS.Add(item);
                }
            }
            k = 0;
            List<KeyValuePair<string, int>> sortedEleUsers = new List<KeyValuePair<string, int>>();
            foreach (var item in elUsers)
            {
                k++;
                sortedEleUsers.Add(new KeyValuePair<string, int>(item.Key.FullName, item.Value));
            }
            sortedEleUsers = (from i in sortedEleUsers orderby i.Value descending select i).ToList();
            List<KeyValuePair<string, int>> sortedEleUsersG = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> sortedEleUsersS = new List<KeyValuePair<string, int>>();
            KeyValuePair<string, int> g = sortedEleUsers[0];
            KeyValuePair<string, int> h = sortedEleUsers[k - 1];
            foreach (var item in sortedEleUsers)
            {
                if (item.Value == g.Value)
                {
                    sortedEleUsersG.Add(item);
                }
                if (item.Value == h.Value)
                {
                    sortedEleUsersS.Add(item);
                }
            }
            InfographicsData model = new InfographicsData()
            {
                averElectricity = ae / (double)counterE,
                averGas = ag / (double)counterG,
                averWater = aw / (double)counterW,
                averWorkersIndex = (double)counter / (double)ki,
                workersAll = workersSorted,
                workersGreat = workersGreatest,
                workersSmall = workersSmallest,
                userElectricityAll = sortedEleUsers,
                userElectricityGreat = sortedEleUsersG,
                userElectricitySmall = sortedEleUsersS,
                userGasAll = sortedGasUsers,
                userGasGreat = sortedGasUsersG,
                userGasSmall = sortedGasUsersS,
                userWaterAll = sortedWaterUsers,
                userWaterGreat = sortedWaterUsersG,
                userWaterSmall = sortedWaterUsersS,
                chartList = chartList
            };

            return PartialView("InfographicsPartial", model);
        }

        public IActionResult Infographics()
        {
            var a = _users.getAll();
            var b = _workers.getAll();
            List<List<string>> q = new List<List<string>>();
            List<string> w = new List<string>();
            List<string> e = new List<string>();
            foreach (var i in a)
            {
                w.Add(i.FullName);
            }
            q.Add(w);
            foreach (var i in b)
            {
                e.Add(i.FullName);
            }
            q.Add(e);
            return View("Infographics", q);
        }
        public IActionResult Index()
        {
            
            var assetModels = _assets.getAll();
            var ListingResult = assetModels
                .Select(result => new AssetIndexListingModel()
                {
                    Id = result.Id,
                    UsersId = result.user.Id,
                    UsersFullName = result.user.FullName,
                    UsersBirthDay = result.user.BirthDate,
                   // Email = result.user.LoginInfo.Email,
                    //Password = result.user.LoginInfo.Password,
                    typeId = result.worker.type.Id,
                    unit = result.worker.type.Unit,
                    limit = result.worker.type.Limit,
                    amount = result.amount,
                    date = result.date,
                    workerFullName = result.worker.FullName,
                    workerPhone = result.worker.MobilePhone
                });

            var model = new CatalogIndexModel()
            {
                Assets = ListingResult
            };

            return View(model);
        }
    }
}
