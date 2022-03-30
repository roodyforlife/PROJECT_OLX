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
        private readonly IFileService _fileService;
        private readonly IDbApplicationService _applicationService;
        private readonly IDbUserService _userService;
        public ProfileController(IDbApplicationService applicationService, IFileService fileService, IDbUserService userService)
        {
            _applicationService = applicationService;
            _fileService = fileService;
            _userService = userService;
        }
        [HttpGet]
        public ViewResult Profile(string userId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            List<Add> adds = _applicationService.GetSomeByUserName(userId);
            ViewBag.UserBaze = _userService.Get(userId);
            ViewBag.User = userName;
            ViewBag.UserId = userId;
            return View(adds);
        }
        [HttpPost]
        public IActionResult Profile()
        {
            ViewBag.Baze = _applicationService.GetAll();
            ControllerContext.HttpContext.Session.Remove("Name");
            ViewBag.Account = null;
            return RedirectPermanent("../Home/Index");
        }
        public IActionResult Del(int addId)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            _applicationService.Del(_applicationService.Get(addId));
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
        public async Task<IActionResult> ProfilePhotoAdd(string userId, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = _userService.Get(userName);
            if (user != null && uploadedFile.Length < 3145728)
            {
                _userService.Del(user);
                user.Avatar = _fileService.GetFileFrom(uploadedFile);
                _userService.Add(user);
            }
            return RedirectPermanent($"../Profile/Profile?userId={userName}");
        }
    }
}