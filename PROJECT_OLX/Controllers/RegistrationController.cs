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
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        public RegistrationController(IDbApplicationService applicationService, IDbUserService userService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
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
                userService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
            }
            catch (Exception)
            {
                return View();
            }
            /*ViewBag.Baze = applicationService.GetAll();*/
            return RedirectPermanent("../Home/Index");
        }
    }
}
