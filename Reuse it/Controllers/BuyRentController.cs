using Microsoft.AspNetCore.Mvc;
using Reuse_it.Models.services;
using Reuse_it.Models;
using Reuse_it.Models.viewModels;

namespace Reuse_it.Controllers
{
    public class BuyRentController : Controller
    {
        private readonly IProductService productService;
        public BuyRentController(IProductService p)
        {

            productService = p;
        }
        public IActionResult Home() {
            
            List<ProductViewModel> pvmList = productService.GetProducts();
            return View(pvmList);
        }
        public IActionResult ProductDetail(int id) {
            
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
