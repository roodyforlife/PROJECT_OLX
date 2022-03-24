using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PROJECT_OLX.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public ProfileController(ApplicationContext _db, IWebHostEnvironment appEnvironment)
        {
            db = _db;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public ViewResult Profile(User user, string userId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Baze = db.Adding.ToList().FindAll(x => x.userName == userName);
            ViewBag.UserBaze = db.Users.FirstOrDefault(x => x.Name == userName);
            ViewBag.User = userName;
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public IActionResult Profile()
        {
            ViewBag.Baze = db.Adding.ToList();
            ControllerContext.HttpContext.Session.Remove("Name");
            ViewBag.Account = null;
            return RedirectPermanent("../Home/Index");
        }
        public IActionResult Del(int addId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            var add = db.Adding.FirstOrDefault(x => x.Id == addId);
            db.Adding.Remove(add);
            db.SaveChanges();
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
        public async Task<IActionResult> ProfilePhotoAdd(string userId, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            //var users = db.Users.ToList();
            var user = db.Users.FirstOrDefault(c => c.Name == userName);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                if (uploadedFile != null)
                {
                    string path = "/Files/Users/" + uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    user.AvatarName = uploadedFile.FileName;
                    user.AvatarPath = path;
                }
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
    }
}