using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVCUyg.Data;
using CoreMVCUyg.Models;

namespace CoreMVCUyg.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public AboutsController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}


		// GET: Admin/Abouts
		public async Task<IActionResult> Index()
        {
              return View(await _context.About.ToListAsync());
        }

        // GET: Admin/Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.About == null)
            {
                return NotFound();
            }

            var about = await _context.About
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Admin/Abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,ShortDescription,Description,ImagePath")] About about, IFormFile File)
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
				about.ImagePath = File.FileName;
			}
			_context.Add(about);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	

        // GET: Admin/Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.About == null)
            {
                return NotFound();
            }

            var about = await _context.About.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,ShortDescription,Description,ImagePath")] About about, IFormFile File)
        {
            if (id != about.Id)
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
				about.ImagePath = File.FileName;
			}
			_context.Update(about);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Abouts/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.About == null)
            {
                return NotFound();
            }

            var about = await _context.About
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.About == null)
            {
                return Problem("Entity set 'ApplicationDbContext.About'  is null.");
            }
            var about = await _context.About.FindAsync(id);
            if (about != null)
            {
                _context.About.Remove(about);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
          return _context.About.Any(e => e.Id == id);
        }
    }
}
