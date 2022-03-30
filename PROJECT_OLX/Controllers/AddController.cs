using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PROJECT_OLX.Interfaces;

namespace PROJECT_OLX.Controllers
{
    public class AddController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IDbApplicationService _applicationService;
        private readonly IDbUserService _userService;
        private readonly ApplicationContext _db; 
        public AddController(ApplicationContext db, IDbApplicationService applicationService, IFileService fileService, IDbUserService userService)
        {
            _applicationService = applicationService;
            _fileService = fileService;
            _userService = userService;
            _db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = _userService.Get(userName);
            if (user is null)
            {
                return RedirectPermanent("../Home/Index");
            }
                return View();
            }
            [HttpPost]
            public IActionResult Add(Add add, IFormFileCollection uploads)
            {
            if (ModelState.IsValid && uploads is not null && uploads.FirstOrDefault(x => x.Length > 3145728) is null && uploads.Count <= 5)
            {
                add.userName = ControllerContext.HttpContext.Session.GetString("Name");
                add.Photos.AddRange(_fileService.GetFilesFrom(uploads));
                _applicationService.Add(add);
                return RedirectPermanent("../Home/Index");
            }
            ViewBag.IsFileValid = uploads is not null || uploads.FirstOrDefault(x => x.Length > 3145728) is null || uploads.Count <= 5 ? "field-validation-file-error" : "";
            return View();
            }

        }
    }