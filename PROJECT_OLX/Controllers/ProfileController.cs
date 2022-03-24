using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PROJECT_OLX.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext db;
        public ProfileController(ApplicationContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ViewResult Profile(User user)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Baze = db.Adding.ToList().FindAll(x => x.userName == userName);
            ViewBag.UserBaze = db.Users.FirstOrDefault(x => x.Name == userName);
            
            return View();
        }
        [HttpPost]
        public IActionResult Profile()
        {
            ViewBag.Baze = db.Adding.ToList();
            ControllerContext.HttpContext.Session.Remove("Name");
            ViewBag.Account = null;
            return RedirectPermanent("../Home/Index");
        }
        public IActionResult Del(int addId)
        {
            var add = db.Adding.FirstOrDefault(x => x.Id == addId);
            db.Adding.Remove(add);
            db.SaveChanges();
            return RedirectPermanent("../Profile/Profile");
        }
        public IActionResult Redact()
        {
            return RedirectPermanent("../Redact/Redact");
        }
    }
}