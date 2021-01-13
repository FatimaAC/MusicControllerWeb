using Microsoft.AspNetCore.Mvc;

namespace MusicControllerWeb.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
