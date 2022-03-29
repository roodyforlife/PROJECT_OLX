using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IFileService
    {
        public void SaveFileTo(string path, IFormFile file);
        public byte[] SaveFileTov2(IFormFile file);
    }
}
