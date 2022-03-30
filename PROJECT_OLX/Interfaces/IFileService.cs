using Microsoft.AspNetCore.Http;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IFileService
    {
        public byte[] GetFileFrom(IFormFile file);
        public List<Photo> GetFilesFrom(IFormFileCollection files);
    }
}
