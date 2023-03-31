using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCUyg.Controllers
{
    public class ProductController : Controller
    {
		private readonly ApplicationDbContext _context;
		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }

		public IActionResult ProductCategory(string seo_bas)
		{
			var kats = _context.Product.Where(x => x.ProductCategorys.ProductCategoryName == seo_bas);
			var anakat = _context.ProductCategory.FirstOrDefault(x => x.ProductCategoryName == seo_bas);
			ViewBag.katadi = anakat.ProductCategoryName;
			return View(kats);

		}
		public IActionResult ProductSubCategory(string seo_bas)
		{
			var kats = _context.Product.Where(x => x.ProductSubCategorys.ProductSubCategoryName == seo_bas);
			var anakat = _context.ProductSubCategory.FirstOrDefault(x => x.ProductSubCategoryName == seo_bas);
			ViewBag.katadi = anakat.ProductSubCategoryName;
			return View(kats);

		}
		public IActionResult ProductMainCategory(string seo_bas)
		{
			var kats = _context.Product.Where(x => x.ProductMainCategorys.ProductMainCategoryName == seo_bas);
			var anakat = _context.ProductMainCategory.FirstOrDefault(x => x.ProductMainCategoryName == seo_bas);
			ViewBag.katadi = anakat.ProductMainCategoryName;
			return View(kats);

		}
		public IActionResult ProductDetail(int id)
		{
			var products = _context.Product.FirstOrDefault(x => x.UrunID == id);
			return View(products);

		}
	}
}
