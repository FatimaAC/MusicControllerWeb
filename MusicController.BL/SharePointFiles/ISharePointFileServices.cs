using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MusicController.BL.SharePointFiles
{
    public interface ISharePointFileServices
    {
        Task<string> SaveFile(IFormFile file, long TrackId);
    }
}
