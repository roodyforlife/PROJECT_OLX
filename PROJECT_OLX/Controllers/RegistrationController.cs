using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;

namespace PROJECT_OLX.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationContext db;
        public RegistrationController(ApplicationContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            try
            {
                user.AvatarPath = "/img/default_avatar.png";
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View();
            }
            ViewBag.Baze = db.Adding.ToList();
            //ControllerContext.HttpContext.Session.SetString("Name", user.Name);
            return RedirectPermanent("../Home/Index");
        }
    }
}
