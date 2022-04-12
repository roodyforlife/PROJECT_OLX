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
        private readonly IFilterAndSortService filterAndSortservice;
        public HomeController(IDbUserService userService, IDbApplicationService applicationService, IFilterAndSortService filterAndSortservice)
        {
            this.userService = userService;
            this.applicationService = applicationService;
            this.filterAndSortservice = filterAndSortservice;
        }

        public IActionResult Index(SearchViewModel search)
        {
        var user = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            ViewBag.UserBaze = userService.Get(user);
                ViewBag.AddBaze = applicationService.GetAll();
            ViewBag.Categories = filterAndSortservice.AllCategories;
            return View();
        }
        public IActionResult Profile()
        {
            return RedirectPermanent("../Profile/Profile");
        }
    }
}