using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Controllers
{
    public class AdOfUserController : Controller
    {
        private readonly ApplicationContext db;
        public AdOfUserController(ApplicationContext _db)
        {
            db = _db;
        }
        public IActionResult AdOfUser(int addId)
        {
            var userAdd = db.Adding.FirstOrDefault(x => x.Id == addId);
            var userAccount = db.Users.FirstOrDefault(x => x.Name == userAdd.userName);
            ViewBag.AddBaze = userAdd;
            ViewBag.UserBaze = userAccount;
            ViewBag.AllAddBaze = db.Adding.ToList().FindAll(x => x.userName == userAccount.Name);
            return View();
        }
    }
}
