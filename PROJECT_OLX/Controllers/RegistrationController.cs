using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Interfaces;

namespace PROJECT_OLX.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IDbApplicationService applicationService;
        public RegistrationController(ApplicationContext db, IDbApplicationService applicationService)
        {
            this.db = db;
            this.applicationService = applicationService;
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
                applicationService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
            }
            catch (Exception)
            {
                return View();
            }
            ViewBag.Baze = db.Adding.ToList();
            return RedirectPermanent("../Home/Index");
        }
    }
}
