using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PROJECT_OLX.Controllers
{
    public class ProfileController : Controller
    {
        public ViewResult Profile(User user)
        {
            return View();
        }
        public IActionResult Exit()
        {
            ControllerContext.HttpContext.Session.Remove("Name");
            ViewBag.Account = null;
            return RedirectPermanent("../Home/Index");
        }
    }
}