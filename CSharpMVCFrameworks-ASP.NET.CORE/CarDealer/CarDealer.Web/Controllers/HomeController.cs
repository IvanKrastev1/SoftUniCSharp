using CarDealer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
