using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IDbUserService userService;
        private readonly IDbApplicationService applicationService;
        public AdminPanelController(IDbUserService userService, IDbApplicationService applicationService)
        {
            this.userService = userService;
            this.applicationService = applicationService;
        }
        public IActionResult AdminPanel()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null || !userService.Get(user).IsAdmin)
                return RedirectPermanent("../Home/Index");
            var allUser = userService.GetAll();
            return View(allUser);
        }
        public IActionResult AdminPanelApplications()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null || !userService.Get(user).IsAdmin)
                return View("../Home/Index");
            List<Add> allAdd = applicationService.GetAll();
            return View(allAdd);
        }
        public IActionResult DeleteApplication(int addId)
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null || !userService.Get(user).IsAdmin)
                return RedirectPermanent("../Home/Index");
            applicationService.Del(applicationService.Get(addId));
            return RedirectPermanent("../AdminPanel/AdminPanelApplications");
        }
        public IActionResult BlockUser(string userId)
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null || !userService.Get(user).IsAdmin)
                return RedirectPermanent("../Home/Index");
            userService.BlockOrUnblock(userService.Get(userId));
            return RedirectPermanent("../AdminPanel/AdminPanel");
        }
        public IActionResult MakeAdmin(string userId)
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (user is null || !userService.Get(user).IsAdmin)
                return RedirectPermanent("../Home/Index");
            userService.MakeAdmin(userId);
            return RedirectPermanent("../AdminPanel/AdminPanel");
        }
    }
}
