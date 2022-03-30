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
        private readonly IDbApplicationService _applicationService;
        private readonly IDbUserService _userService;
        private readonly IAuthorisationService _authorisationService;
        public LoginController(IDbApplicationService applicationService, IDbUserService userService, IAuthorisationService authorisationService)
        {
            _applicationService = applicationService;
            _userService = userService;
            _authorisationService = authorisationService;
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
            if (!_authorisationService.IsRegistered(_userService, user.Name) || !_authorisationService.IsCorrectPassword(_userService, user))
            {
                ModelState.AddModelError("Password", "Невірний логін або пароль");
            }
            if(ModelState.IsValid)
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Name);
                ViewBag.Baze = _applicationService.GetAll();
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }

    }
}
