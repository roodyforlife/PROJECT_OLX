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

        public byte[] SaveFileTo(IFormFile file)
        {
            if (file is null)
            {
                throw new ArgumentException();
            }
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)file.Length);
            }
            return imageData;
        }
    }
}
