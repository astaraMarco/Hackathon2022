using Microsoft.AspNetCore.Mvc;
using Reuse_it.Models.services;
using Reuse_it.Models;
using Reuse_it.Models.viewModels;

namespace Reuse_it.Controllers
{
    public class BuyRentController : Controller
    {
        public IActionResult Home() {
            ProductService productService = new ProductService();
            List<ProductViewModel> pvmList = productService.GetProduct();
            return View(pvmList);
        }
        public IActionResult ProductDetail(int id) {
            ProductService productService = new ProductService();
            ProductViewModel pvm = productService.GetProduct(id);
            return View(pvm);
        }

        public IActionResult Buy(int id)
        {
            return RedirectToAction(nameof(Home));
        }
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Home));
        }
    }
}
