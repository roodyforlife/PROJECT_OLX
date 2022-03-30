using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using PROJECT_OLX.Interfaces;

namespace PROJECT_OLX.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbUserService _userService;
        private readonly IDbApplicationService _applicationService;
        public HomeController(IDbUserService userService, IDbApplicationService applicationService)
        {
            _userService = userService;
            _applicationService = applicationService;
        }

        public ViewResult Index(string search)
        {
        var user = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            ViewBag.UserBaze = _userService.Get(user);
            List<Add> adds;
            if (search is null)
            {
                adds = _applicationService.GetAll();
            }
            else
            {
                adds = _applicationService.GetSomeBySearch(search);
            }
            return View(adds);
        }
        public IActionResult Profile()
        {
            return RedirectPermanent("../Profile/Profile");
        }
    }
}