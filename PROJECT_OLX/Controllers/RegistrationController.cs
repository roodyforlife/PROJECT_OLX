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
        private readonly IDbApplicationService _applicationService;
        private readonly IDbUserService _userService;
        private readonly IAuthorisationService _authorisationService;
        public RegistrationController(IDbApplicationService applicationService, IDbUserService userService, IAuthorisationService authorisationService)
        {
            _applicationService = applicationService;
            _userService = userService;
            _authorisationService = authorisationService;
        }
        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            
            if (user.Name != null && _authorisationService.IsRegistered(_userService, user.Name))
            {
                ModelState.AddModelError("Name", "Такий акаунт вже існує.");
            }
            if (ModelState.IsValid)
            {
                byte[] arr = new byte[] { 0, 1, 1, 2, 0};
                user.Avatar = arr;
                _userService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
