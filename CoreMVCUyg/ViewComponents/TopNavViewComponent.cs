using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
    [ViewComponent]
    public class TopNavViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public TopNavViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _context.WebsiteInfo.ToListAsync());
        }
    }
}

