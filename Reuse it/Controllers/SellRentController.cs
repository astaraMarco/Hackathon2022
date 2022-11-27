using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySqlX.XDevAPI;
using Reuse_it.Enumerations;
using Reuse_it.Models;
using Reuse_it.Models.services;
using Reuse_it.Models.viewModels;
using System.Data.Entity;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
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


            /*

            string query = "";
            await product.foto.ConvertIFromFileInPath();
           
               
                byte[] file= null;
                using (var fs1 = product.foto.PostedFile.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fs1.CopyTo(ms);
                
                    file = ms.ToByteArray();
                }
                

            query = $"INSERT INTO `prodotto`( `nome`, `descrizione`, `grandezza`, `usura`, `price_buy`, `price_rent`) VALUES ('{product.nome}','{product.descrizione}','{product.size.ToString()}','{product.usura.ToString()}','{product.priceBuy}','NULL');\r\n" +
                $"INSERT INTO `foto`(`img`,`fk_prodotto`) VALUES ({System.IO.File.ReadAllBytes(product.foto.pathFoto)},last_insert_id()) ";
            
            products.addProduct(query);
            
            
            Size size = new Size(height, width, depth, grandezza);

            
            
            
            
            switch (condizioni)
            {
                case "1":
                    usura = Usury.nuovo;

                break;
                case "2":
                    usura = Usury.ottimo;

                break;
                case "3":
                    usura = Usury.buono;

                break;
                case "4":
                    usura = Usury.discreto;

                break;
                case "5":
                    usura = Usury.pessimo;

                break;
                default:
                    usura = Usury.pessimo;
                break;
            }


            string query = $"INSERT INTO `prodotto`( `nome`, `descrizione`, `grandezza`, `usura`, `price_buy`, `price_rent`) VALUES ('{nome}','{descrizione}','{size.ToString()}','{usura.ToString()}','{price}','NULL');\r\n" +
                $"INSERT INTO `foto`(`img`,`fk_prodotto`) VALUES ({blob},last_insert_id()) ";
            products.addProduct(query);
            */
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
