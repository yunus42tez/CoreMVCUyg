using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCUyg.Areas.Controllers
{
	public class DashboardController : Controller
	{
		[Area("Admin")]
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
