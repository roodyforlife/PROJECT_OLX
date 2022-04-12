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
        private readonly IFileService fileService;
        private readonly IDbApplicationService applicationService;
        private readonly IDbUserService userService;
        private readonly ApplicationContext db;
        private readonly IFilterAndSortService filterAndSortService;
        public AddController(IDbApplicationService applicationService, IFileService fileService, IDbUserService userService, IFilterAndSortService filterAndSortService)
        {
            this.applicationService = applicationService;
            this.fileService = fileService;
            this.userService = userService;
            this.filterAndSortService = filterAndSortService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = userService.Get(userName);
            ViewBag.Categories = filterAndSortService.AllCategories;
            if (user is null)
            {
                return RedirectPermanent("../Home/Index");
            }
                return View();
            }
            [HttpPost]
            public IActionResult Add(Add add, IFormFileCollection uploads)
            {
            if (ModelState.IsValid && uploads.Count > 0 && uploads.FirstOrDefault(x => x.Length > 3145728) is null && uploads.Count <= 5)
            {
                add.userName = ControllerContext.HttpContext.Session.GetString("Name");
                add.Photos.AddRange(fileService.GetFilesFrom(uploads));
                applicationService.Add(add);
                return RedirectPermanent("../Home/Index");
            }
            ViewBag.IsFileValid = uploads.Count > 0 || uploads.FirstOrDefault(x => x.Length > 3145728) is null || uploads.Count <= 5 ? "field-validation-file-error" : "";
            ViewBag.Categories = filterAndSortService.AllCategories;
            return View();
            }

        }
    }