using Microsoft.AspNetCore.Mvc;

namespace CoreMVCUyg.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
