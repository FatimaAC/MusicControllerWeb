﻿using Microsoft.AspNetCore.Mvc;

namespace MusicControllerWeb.Controllers
{
    public class OutletController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Schedule()
        {
            return View();
        }
    }
}
