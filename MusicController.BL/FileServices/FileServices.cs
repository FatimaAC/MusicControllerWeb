using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MusicController.Shared;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MusicController.BL.FileServices
{
    public class FileServices : IFileServices
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileServices(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            FileMetaInformation fileMetaInformation = new FileMetaInformation
            {
                FileName = file.FileName,
                UniqueName = Guid.NewGuid().ToString("N")
            };
            if (!fileMetaInformation.IsImage)
            {
                throw new Exception("Bad Format");
            }
            string path = Path.Combine(_hostEnvironment.WebRootPath, fileMetaInformation.RelivtivePath);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileMetaInformation.RelivtivePath;
        }
    }
}
