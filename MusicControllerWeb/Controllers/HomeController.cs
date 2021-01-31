using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicControllerWeb.Models;

namespace MusicControllerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            ErrorViewModel error = new ErrorViewModel()
            {
                StatusCode = statusCode
            };
            switch (statusCode)
            {
                case 404:
                    error.Message = "OOPS! PAGE NOT BE FOUND";
                    error.Description = "Sorry but the page you are looking for does not exist, have been removed. name changed or is temporarily unavailable";
                    break;
                case 500:
                    error.Message = "Unexpected Message";
                    error.Description = "Sorry, something went wrong on our end. We are currently trying to fix the problem.";
                    break;
                default:
                    error.Message = "Unexpected Message";
                    error.Description = "Sorry, something went wrong on our end. We are currently trying to fix the problem.";
                    break;
            }
            return View(error);
        }
    }
}
