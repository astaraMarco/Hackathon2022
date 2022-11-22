using Microsoft.AspNetCore.Mvc;
using Reuse_it.Models;
using Reuse_it.Models.services;

namespace Reuse_it.Controllers
{
    public class SellRentController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Sell()
        {
            return View();
        }

       

        public IActionResult Rent()
        {

            return View();
        }
        public IActionResult SellOrRent()
        {

            return View();
        }
    }
}
