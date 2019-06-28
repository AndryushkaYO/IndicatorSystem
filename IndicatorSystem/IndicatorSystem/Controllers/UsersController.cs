using IndicatorData;
using IndicatorData.Models;
using IndicatorSystem.Models.Catalog;
using IndicatorSystem.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndicatorSystem.Controllers
{
    public class UsersController:Controller
    {
        static private IUser _users;
        public string valueSort="";
        public UsersController(IUser user)
        {
            _users = user;
        }
        public IActionResult Add(string value)
        {
            string[] user = value.Split('*');
            string[] data = user[2].Split('-');
            LoginInfo w = new LoginInfo()
            {
                Email = user[3],
                Password = user[4]
            };
            User a = new User() {
                Id = user[0],
                FullName = user[1],
                BirthDate = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2])),
                LoginInfo = w
                };
            _users.Add(a);
            var assetModels = _users.getAll();
            
            var ListingResult = assetModels
                .Select(result => new UsersListingModel()
                {
                    UsersId = result.Id,
                    UsersFullName = result.FullName,
                    UsersBirthDay = result.BirthDate,
                    Email = result.LoginInfo.Email,
                    Password = result.LoginInfo.Password
                });
            var model = new UsersModel()
            {
                Assets = ListingResult
            };
            //model.sortBy(value);
            return PartialView("Partial", model);
        }
        public IActionResult Partial(string value)
        {
            var assetModels = _users.getAll();
            var ListingResult = assetModels
                .Select(result => new UsersListingModel()
                {
                    UsersId = result.Id,
                    UsersFullName = result.FullName,
                    UsersBirthDay = result.BirthDate,
                    Email = result.LoginInfo.Email,
                    Password = result.LoginInfo.Password
                });
            var model = new UsersModel()
            {
                Assets = ListingResult
            };
            model.sortBy(value);
            return PartialView("Partial", model);
        }

        public IActionResult Delete(string id)
        {
            _users.Delete(_users.GetById(id));

            var assetModels = _users.getAll();

            var ListingResult = assetModels
                .Select(result => new UsersListingModel()
                {
                    UsersId = result.Id,
                    UsersFullName = result.FullName,
                    UsersBirthDay = result.BirthDate,
                    Email = result.LoginInfo.Email,
                    Password = result.LoginInfo.Password
                });
            var model = new UsersModel()
            {
                Assets = ListingResult
            };
            return PartialView("Partial", model); 
        }
            public IActionResult Index()
        {
            var assetModels = _users.getAll();
            var ListingResult = assetModels
                .Select(result => new UsersListingModel()
                {                    
                    UsersId = result.Id,
                    UsersFullName = result.FullName,
                    UsersBirthDay = result.BirthDate,
                    Email = result.LoginInfo.Email,
                    Password = result.LoginInfo.Password
                });

            var model = new UsersModel()
            {
                Assets = ListingResult
            };

            return View(model);
        }
    }
}
