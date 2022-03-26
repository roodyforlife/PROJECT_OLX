using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PROJECT_OLX.Interfaces;

namespace PROJECT_OLX.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IFileService fileService;
        private readonly IDbApplicationService applicationService;
        public ProfileController(ApplicationContext db, IDbApplicationService applicationService, IFileService fileService)
        {
            this.db = db;
            this.applicationService = applicationService;
            this.fileService = fileService;
        }
        [HttpGet]
        public ViewResult Profile(string userId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Baze = db.Adding.ToList().FindAll(x => x.userName == userId);
            ViewBag.UserBaze = db.Users.FirstOrDefault(x => x.Name == userId);
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
            applicationService.Del(add);
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
        public async Task<IActionResult> ProfilePhotoAdd(string userId, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = db.Users.FirstOrDefault(c => c.Name == userName);
            if (user != null)
            {
                applicationService.Del(user);
                user.AvatarPath = "/Files/Users/" + uploadedFile.FileName;
                fileService.SaveFileTo("/Files/Users/", uploadedFile);
                applicationService.Add(user);
            }
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
    }
}