﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Controllers
{
    public class RedactController : Controller
    {
        private readonly ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public RedactController(ApplicationContext _db, IWebHostEnvironment appEnvironment)
        {
            db = _db;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public ViewResult Redact()
        {
            ViewBag.Baze = db.Users.ToList();
            ViewBag.Account = ControllerContext.HttpContext.Session.GetString("Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(User add, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            //var users = db.Users.ToList();
            var user = db.Users.FirstOrDefault(c => c.Name == userName);
            if (user != null)
            {
                string path = "/Files/Users/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                add.Name = uploadedFile.FileName;
                add.AvatarPath = path;
                db.Users.Add(add);
                db.SaveChanges();
            }
            return RedirectPermanent("../Home/Index");
        }


    }
}
