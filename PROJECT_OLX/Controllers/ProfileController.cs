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
        private readonly IFileService fileService;
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        public ProfileController(IDbApplicationService applicationService, IFileService fileService, IDbUserService userService)
        {
            this.applicationService = applicationService;
            this.fileService = fileService;
            this.userService = userService;
        }
        [HttpGet]
        public ViewResult Profile(string userId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            List<Add> adds = applicationService.GetSome(userId);
            ViewBag.UserBaze = userService.Get(userId);
            ViewBag.User = userName;
            ViewBag.UserId = userId;
            return View(adds);
        }
        [HttpPost]
        public IActionResult Profile()
        {
            ViewBag.Baze = applicationService.GetAll();
            ControllerContext.HttpContext.Session.Remove("Name");
            ViewBag.Account = null;
            return RedirectPermanent("../Home/Index");
        }
        public IActionResult Del(int addId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            var add = applicationService.Get(addId);
            applicationService.Del(add);
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
        public async Task<IActionResult> ProfilePhotoAdd(string userId, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = userService.Get(userName);
            if (user != null)
            {
                userService.Del(user);
                user.AvatarPath = "/Files/Users/" + uploadedFile.FileName;
                fileService.SaveFileTo("/Files/Users/", uploadedFile);
                userService.Add(user);
            }
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
    }
}