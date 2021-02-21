using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MusicController.Common.Enumerration;
using MusicController.Common.HelperClasses;
using MusicController.Shared.ExpectionHelper;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MusicController.BL.SharePointFiles
{
    public class SharePointFileServices: ISharePointFileServices
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IConfiguration _iConfig;
        public SharePointFileServices(IWebHostEnvironment hostEnvironment,IConfiguration EnvironmentConfig)
        {
            _hostEnvironment = hostEnvironment;
            _iConfig = EnvironmentConfig; 
        }

        public async Task<string> SaveFile(IFormFile file, long TrackId)
        {
            string FilePathConn = _iConfig.GetValue<string>("MySettings:FileRepositoryPath");

            TrackFileMetaInformation fileMetaInformation = new TrackFileMetaInformation
            {
                FileName = file.FileName,
                UniqueName = Guid.NewGuid().ToString("N")
            };
            if (!fileMetaInformation.IsTrack)
            {
                throw new UserFriendlyException("File is not a sound track", StatusApiEnum.Failure);
            }
            string path = Path.Combine(FilePathConn, TrackId +"-"+fileMetaInformation.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}
