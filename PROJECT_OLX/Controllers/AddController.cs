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
        private readonly ApplicationContext db;
        private readonly IFileService fileService;
        private readonly IDbApplicationService applicationService;
        public AddController(ApplicationContext db, IDbApplicationService applicationService, IFileService fileService)
        {
            this.db = db;
            this.applicationService = applicationService;
            this.fileService = fileService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = db.Users.FirstOrDefault(c => c.Name == userName);
            if (user is null)
            {
                return RedirectPermanent("../Home/Index");
            }
                return View();
            }
            [HttpPost]
            public IActionResult Add(Add add, IFormFile uploadedFile)
            {
            //ModelState["Cost"].Errors.Remove(ModelState["Cost"].Errors.FirstOrDefault(c => c.ErrorMessage == "The value '' is invalid."));
            if (ModelState.IsValid)
            {
                add.Path = "/Files/Add/" + uploadedFile.FileName;
                add.userName = ControllerContext.HttpContext.Session.GetString("Name");
                fileService.SaveFileTo("/Files/Add/", uploadedFile);
                applicationService.Add(add);
                return RedirectPermanent("../Home/Index");
            }
            ViewBag.IsFileValid = uploadedFile is null ? "field-validation-file-error" : "";
            return View();
            }

        }
    }