using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
	[ViewComponent]
	public class NavbarMenuViewComponent: ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public NavbarMenuViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			return View(await _context.ProductMainCategory.ToListAsync());
		}
	}
}

