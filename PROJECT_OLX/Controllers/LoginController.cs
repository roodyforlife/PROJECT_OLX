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
    public class LoginController : Controller
    {
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public LoginController(IDbApplicationService applicationService, IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
            this.authorisationService = authorisationService;
        }

        [HttpGet]
        public ViewResult Login()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            if (userName is null)
            {   
                return View();
            }
                return View("../Home/Index");
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            /*var users = userService.GetAll();*/
            /*if (users.Exists(x => x.Name == user.Name && x.Password == user.Password))*/
            if (!authorisationService.IsRegistered(userService, user.Name) || !authorisationService.IsCorrectPassword(userService, user))
            {
                ModelState.AddModelError("Password", "Невірний логін або пароль");
            }
            if(ModelState.IsValid)
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
                ViewBag.Baze = applicationService.GetAll();
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }

    }
}
