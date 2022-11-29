using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Reuse_it.Enumerations;
using Reuse_it.Models;
using Reuse_it.Models.services;
using Reuse_it.Models.viewModels;
using System.Data.Entity;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

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
        public async Task<IActionResult> SellCheck(ProductViewModel product)
        {
            await products.addProduct(product);
            return RedirectToAction(nameof(Sell));
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
