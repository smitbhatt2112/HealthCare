﻿using HealthCare.BAL;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthCare.Controllers
{
    [CheckAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(User_MasterModel d)
        {
            //return View();
            if (d.UserName == "Admin" && d.Password == "Admin")
            {
                return View();
            }
            else
            {
                return View("HomeClient");  
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}