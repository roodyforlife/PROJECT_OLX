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
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public RegistrationController(IDbApplicationService applicationService, IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
            this.authorisationService = authorisationService;
        }
        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            
            if (user.Name != null && authorisationService.IsRegistered(userService, user.Name))
            {
                ModelState.AddModelError("Name", "Такий акаунт вже існує.");
            }

            if (ModelState.IsValid)
            {
                user.AvatarPath = "/img/default_avatar.png";
                userService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
