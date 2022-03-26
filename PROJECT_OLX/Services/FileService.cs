using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public FileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public void SaveFileTo(string path, IFormFile file)
        {
            if(file is null || path is null || path == String.Empty)
            {
                throw new ArgumentException();
            }
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + file.FileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
