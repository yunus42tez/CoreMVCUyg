using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
	[ViewComponent]
	public class NavbarMenuSubCategoryViewComponent:ViewComponent
	{
		private readonly ApplicationDbContext _context;
		public NavbarMenuSubCategoryViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(int? productMainCategoryId)
		{

			return View(await _context.ProductSubCategory.FromSql($"select * from ProductSubCategory where ProductMainCategoryId={productMainCategoryId}").ToListAsync());
		}
	}
}

