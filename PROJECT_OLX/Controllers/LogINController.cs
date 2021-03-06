using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Interfaces;

namespace PROJECT_OLX.Controllers
{
    public class LogINController : Controller
    {
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public LogINController(IDbApplicationService applicationService, IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
            this.authorisationService = authorisationService;
        }

        [HttpGet]
        public IActionResult LogIN()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null)
            {   
                return View();
            }
                return RedirectPermanent("../Home/Index");
        }
        [HttpPost]
        public IActionResult LogIN(LoginUser user)
        {
            if (!authorisationService.IsRegistered(userService, user.Login) || !authorisationService.IsCorrectPassword(userService, user))
            {
                ModelState.AddModelError("Password", "Невірний логін або пароль");
            }
            if(ModelState.IsValid)
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Login);
                ViewBag.Baze = applicationService.GetAll();
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }

    }
}
