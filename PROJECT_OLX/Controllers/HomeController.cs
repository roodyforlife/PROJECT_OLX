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
        private readonly IFilterAndSortService filterAndSortService;
        public HomeController(IDbUserService userService, IDbApplicationService applicationService, IFilterAndSortService filterAndSortService)
        {
            this.userService = userService;
            this.applicationService = applicationService;
            this.filterAndSortService = filterAndSortService;
        }

        public IActionResult Index(SearchViewModel search)
        {
        var user = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            ViewBag.UserBaze = userService.Get(user);
            ViewBag.AddBaze = applicationService.GetSomeBySearch(search);
            ViewBag.Sorts = filterAndSortService.AllSort;
            ViewBag.Categories = filterAndSortService.AllCategories;
            return View();
        }
        public IActionResult Profile()
        {
            return RedirectPermanent("../Profile/Profile");
        }
    }
}