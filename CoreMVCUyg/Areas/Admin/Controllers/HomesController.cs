using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVCUyg.Data;
using CoreMVCUyg.Models;
using Microsoft.Extensions.Hosting;

namespace CoreMVCUyg.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public HomesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
			_environment = environment;
		}

        // GET: Admin/Homes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Home.ToListAsync());
        }

        // GET: Admin/Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Admin/Homes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,ShortDescription,Description,ImagePath")] Home home, IFormFile File)
        {
			if (File != null && File.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File.CopyToAsync(stream);
				}

				// dosya adı entity'e atanır
				home.ImagePath = File.FileName;
			}
			    _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         

        // GET: Admin/Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        // POST: Admin/Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,ShortDescription,Description,ImagePath")] Home home, IFormFile File)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

			if (File != null && File.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File.CopyToAsync(stream);
				}

				// dosya adı entity'e atanır
				home.ImagePath = File.FileName;
			}
			_context.Update(home);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


		// GET: Admin/Homes/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Home == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Admin/Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Home == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Home'  is null.");
            }
            var home = await _context.Home.FindAsync(id);
            if (home != null)
            {
                _context.Home.Remove(home);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
          return _context.Home.Any(e => e.Id == id);
        }
    }
}
