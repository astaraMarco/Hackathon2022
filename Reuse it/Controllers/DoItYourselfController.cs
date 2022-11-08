using Microsoft.AspNetCore.Mvc;

namespace Reuse_it.Controllers
{
    public class DoItYourselfController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
