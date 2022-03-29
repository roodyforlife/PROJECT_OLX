﻿using Microsoft.AspNetCore.Mvc;
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
        public AddController( IDbApplicationService applicationService, IFileService fileService, IDbUserService userService)
        {
            this.applicationService = applicationService;
            this.fileService = fileService;
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = userService.Get(userName);
            if (user is null)
            {
                return RedirectPermanent("../Home/Index");
            }
                return View();
            }
            [HttpPost]
            public IActionResult Add(Add add, IFormFile uploadedFile)
            {
            if (ModelState.IsValid && uploadedFile is not null && uploadedFile.Length < 5245329)
            {
                add.userName = ControllerContext.HttpContext.Session.GetString("Name");
                add.Avatar = fileService.SaveFileTov2(uploadedFile);
                applicationService.Add(add);
                return RedirectPermanent("../Home/Index");
            }
            ViewBag.IsFileValid = uploadedFile is null || uploadedFile.Length > 5245329 ? "field-validation-file-error" : "";
            return View();
            }

        }
    }