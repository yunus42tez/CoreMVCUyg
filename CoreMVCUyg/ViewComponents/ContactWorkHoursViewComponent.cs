using CoreMVCUyg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.ViewComponents
{
    [ViewComponent]
    public class ContactWorkHoursViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ContactWorkHoursViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _context.WebsiteInfo.ToListAsync());
        }
    }
}
