using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace PROJECT_OLX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;
        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        public ViewResult Index(string search)
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");
            if (ControllerContext.HttpContext.Session.Keys.Contains("Name"))
            {
                ViewBag.Account = user;
            }
            else
            {
                ViewBag.Account = null;
            }
            ViewBag.UserBaze = db.Users.FirstOrDefault(x => x.Name == user);
            List<Add> adds;
            if (search is null)
            {
                adds = db.Adding.ToList();
            }
            else
            {
                adds = db.Adding.Where(x => (x.Title + x.Desc)!.Contains(search)).ToList();
            }
            return View(adds);
        }
    }
}