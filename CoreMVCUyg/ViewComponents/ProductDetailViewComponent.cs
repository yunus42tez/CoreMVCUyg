using CoreMVCUyg.Data;
using CoreMVCUyg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
    [ViewComponent]
    public class ProductDetailViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ProductDetailViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            var items = await GetItemsById(id);
            return View(items);
        }
        private Task<List<Product>> GetItemsById(int id)
        {
            return _context.Product.Where(x => x.UrunID == id).ToListAsync();
        }
    }
}
