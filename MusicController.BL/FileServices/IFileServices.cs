using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicController.BL.FileServices
{
   public interface IFileServices
    {
        Task<string> SaveFile(IFormFile file);
    }
}
