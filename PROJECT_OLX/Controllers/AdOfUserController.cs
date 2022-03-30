using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Controllers
{
    public class AdOfUserController : Controller
    {
        private readonly IDbApplicationService _applicationService;
        private readonly IDbUserService _userService;
        public AdOfUserController(IDbApplicationService applicationService, IDbUserService userService)
        {
            _applicationService = applicationService;
            _userService = userService;
        }
        public IActionResult AdOfUser(int addId)
        {
            var userAdd = _applicationService.Get(addId);
            var userAccount = _userService.Get(userAdd.userName);
            ViewBag.AddBaze = userAdd;
            ViewBag.UserBaze = userAccount;
            List<Add> adds = _applicationService.GetSomeByUserName(userAccount.Name);
            return View(adds);
        }
    }
}
