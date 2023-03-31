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
    public class SlidersController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public SlidersController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		// GET: Admin/Sliders
		public async Task<IActionResult> Index()
        {
              return View(await _context.Slider.ToListAsync());
        }

        // GET: Admin/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order,Header,ShortDescription,ImagePath")] Slider slider, IFormFile File)
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
				slider.ImagePath = File.FileName;
			}
			_context.Add(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Sliders/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order,Header,ShortDescription,ImagePath")] Slider slider, IFormFile File)
        {
            if (id != slider.Id)
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
				slider.ImagePath = File.FileName;
			}
			_context.Update(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Sliders/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slider == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
            }
            var slider = await _context.Slider.FindAsync(id);
            if (slider != null)
            {
                _context.Slider.Remove(slider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
          return _context.Slider.Any(e => e.Id == id);
        }
    }
}
