using Microsoft.AspNetCore.Mvc;
using Reuse_it.Models.services;
using Reuse_it.Models;
using Reuse_it.Models.viewModels;
using RestSharp;
using Reuse_it.Models.Api;

namespace Reuse_it.Controllers
{
    public class BuyRentController : Controller
    {
        private readonly ISmartBoxServices smartBoxService;
        private readonly IProductService productService;
        public BuyRentController(IProductService p,ISmartBoxServices s)
        {
            smartBoxService = s;
            productService = p;
        }
        public IActionResult Home() {
            
            var pvmList = productService.GetProducts();
            return View(pvmList);
        }
        public IActionResult ProductDetail(int id) {
            
            var pvm = productService.GetProduct(id);
            return View(pvm);
        }

        public IActionResult Buy(int id)
        {
            // HttpClient client = new HttpClient();

            List<SmartBoxViewModel>? smartBoxList = smartBoxService.SmartBoxGetWithRegions("Lazio");
            List<SmartBoxViewModel>? smartBoxList2 = smartBoxService.SmartBoxGetWithProvincia(smartBoxList,"Roma");
            List<SmartBoxViewModel>? smartBoxList3 = smartBoxService.SmartBoxGetWithNome(smartBoxList2,"Albano Laziale");

            List<SlotViewModels> slots = smartBoxService.GetSlotsLockerFree(smartBoxList3[0].id);
            if (slots != null)
            {
                smartBoxService.BlockingSlot(slots[0].id, id);


            }

            return View(slots[0].id);
        }
        public IActionResult sblockSlots(int id) {
            var result = smartBoxService.ReleaseSlot(id);

            return RedirectToAction(nameof(Home));
        }
        public IActionResult Rent(int id)
        {

            return RedirectToAction(nameof(Home));
        }
    }
}
