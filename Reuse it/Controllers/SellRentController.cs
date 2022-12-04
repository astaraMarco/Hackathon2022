using Microsoft.AspNetCore.Mvc;
using Reuse_it.Models.services;
using Reuse_it.Models.viewModels;

namespace Reuse_it.Controllers
{
    public class SellRentController : Controller
    {
        private readonly IProductService products;
        public SellRentController(IProductService ps)
        {
            products = ps;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Sell()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SellCheck(ProductViewModel product)
        {
            var result = products.addProductSell(product);
            return RedirectToAction(nameof(Sell));
        }

        public IActionResult Rent()
        {

            return View();
        }

        public IActionResult RentCheck()
        {

            return View();
        }
        public IActionResult SellOrRent()
        {

            return View();
        }
        public IActionResult SellRentCheck()
        {

            return View();
        }
    }
}
