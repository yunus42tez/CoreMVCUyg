using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
    [ViewComponent]
    public class ContactGoogleMapViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ContactGoogleMapViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _context.WebsiteInfo.ToListAsync());
        }
    }
}
