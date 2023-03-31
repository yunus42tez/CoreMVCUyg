using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
	[ViewComponent]
	public class AnasayfaIcerikViewComponent: ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public AnasayfaIcerikViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			return View(await _context.Home.ToListAsync());
		}
	}
}
