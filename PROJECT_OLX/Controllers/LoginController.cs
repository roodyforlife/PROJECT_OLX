using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PROJECT_OLX.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationContext db;
        public LoginController(ApplicationContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public ViewResult Login()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            if (userName != null)
            {
                return View("../Home/Index");
            }
                return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var users = db.Users.ToList();
            if (users.Exists(x => x.Name == user.Name && x.Password == user.Password))
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
                ViewBag.Baze = db.Adding.ToList();
                return RedirectPermanent("../Home/Index");
            }
            else
            {
                return View();
            }
        }

    }
}
