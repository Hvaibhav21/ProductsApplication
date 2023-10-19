using Microsoft.AspNetCore.Mvc;
using ProductsApplication.Models;
using System.Diagnostics;

namespace ProductsApplication.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
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
        public IActionResult Play()
        {
            return View();
        }
        public string Ple()
        {
            return "I am playing Cricket";
        }
    }
}