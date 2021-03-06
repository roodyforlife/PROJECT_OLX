using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        public AdvertisementController(IDbApplicationService applicationService, IDbUserService userService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
        }
        public IActionResult Advertisement(int addId)
        {
            var userAdd = applicationService.Get(addId);
            var userAccount = userService.Get(userAdd.userName);
            ViewBag.AddBaze = userAdd;
            ViewBag.UserBaze = userAccount;
            List<Add> adds = applicationService.GetSomeByUserName(userAccount.Login);
            return View(adds);
        }
    }
}
