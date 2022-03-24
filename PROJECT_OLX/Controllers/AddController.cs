using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PROJECT_OLX.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public AddController(ApplicationContext _db, IWebHostEnvironment appEnvironment)
        {
            db = _db;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Add(Add add, IFormFile uploadedFile)
        {
            string userName = ControllerContext.HttpContext.Session.GetString("Name");
            //var users = db.Users.ToList();
            var user = db.Users.FirstOrDefault(c => c.Name == userName);
            if (user != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                add.Name = uploadedFile.FileName;
                add.Path = path;

            add.userName = user.Name;
                db.Adding.Add(add);
                db.SaveChanges();
            }
            return RedirectPermanent("../Home/Index");
        }
    }
}
