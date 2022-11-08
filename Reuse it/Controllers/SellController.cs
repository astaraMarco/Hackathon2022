using Microsoft.AspNetCore.Mvc;

namespace Reuse_it.Controllers
{
    public class SellController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
