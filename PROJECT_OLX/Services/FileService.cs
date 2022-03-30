using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class FileService : IFileService
    {
        public byte[] GetFileFrom(IFormFile file)
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

        public List<Photo> GetFilesFrom(IFormFileCollection files)
        {
            List<byte[]> byteFiles = new List<byte[]>(); 
            foreach(var uploadedFile in files)
            {
                if (uploadedFile is null)
                {
                    throw new ArgumentException();
                }
                using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
                {
                    byteFiles.Add(binaryReader.ReadBytes((int)uploadedFile.Length));
                }
            }
            List<Photo> photos = new();
            foreach (var file in byteFiles)
            {
                photos.Add(new Photo(file));
            }
            return photos;
        }
    }
}
