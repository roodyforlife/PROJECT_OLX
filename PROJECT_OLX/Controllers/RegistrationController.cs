using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Services;

namespace PROJECT_OLX.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public RegistrationController(IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.userService = userService;
            this.authorisationService = authorisationService;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is not null)
            {
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            
            if (user.Email != null && authorisationService.IsRegistered(userService, user.Login))
                ModelState.AddModelError("Login", "Такий акаунт вже існує");

            if (ModelState.IsValid)
            {
                byte[] arr = new byte[] { 0, 1, 1, 2, 0};
                user.Avatar = arr;
                userService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Name", user.Login);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
