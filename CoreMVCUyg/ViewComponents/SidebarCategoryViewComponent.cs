using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
    [ViewComponent]
    public class SidebarCategoryViewComponent: ViewComponent
    {
		private readonly ApplicationDbContext _context;
		public SidebarCategoryViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(int? productSubCategoryId)
		{

			return View(await _context.ProductCategory.FromSql($"select * from ProductCategory where productSubCategoryId={productSubCategoryId}").ToListAsync());
		}
	}
}
