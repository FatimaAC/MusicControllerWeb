using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MusicController.BL.FileServices
{
    public interface IFileServices
    {
        Task<string> SaveFile(IFormFile file);
    }
   
}
