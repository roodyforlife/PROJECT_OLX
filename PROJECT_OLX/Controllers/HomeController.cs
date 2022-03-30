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
        private readonly IDbUserService userService;
        private readonly IDbApplicationService applicationService;
        public HomeController(IDbUserService userService, IDbApplicationService applicationService)
        {
            this.userService = userService;
            this.applicationService = applicationService;
        }

        public ViewResult Index(string search)
        {
        var user = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            ViewBag.UserBaze = userService.Get(user);
            List<Add> adds;
            if (search is null)
            {
                adds = applicationService.GetAll();
            }
            else
            {
                adds = applicationService.GetSomeBySearch(search);
            }
            return View(adds);
        }
        public IActionResult Profile()
        {
            return RedirectPermanent("../Profile/Profile");
        }
    }
}