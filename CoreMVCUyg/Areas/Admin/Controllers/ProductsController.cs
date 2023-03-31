using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVCUyg.Data;
using CoreMVCUyg.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreMVCUyg.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		// GET: Admin/Products
		public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.ProductCategorys).Include(p => p.ProductMainCategorys).Include(p => p.ProductSubCategorys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductCategorys)
                .Include(p => p.ProductMainCategorys)
                .Include(p => p.ProductSubCategorys)
                .FirstOrDefaultAsync(m => m.UrunID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductCategoryName");
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName");
            ViewData["ProductSubCategoryId"] = new SelectList(_context.ProductSubCategory, "ProductSubCategoryId", "ProductSubCategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunID,UrunAd,ImagePath,ImagePath2,ImagePath3,KisaAciklama,Aciklama,Vitrin,ProductMainCategoryId,ProductSubCategoryId,ProductCategoryId")] Product product, IFormFile File, IFormFile File2, IFormFile File3)
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
				product.ImagePath = File.FileName;
				
			}
			if (File2 != null && File2.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File2.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File2.CopyToAsync(stream);
				}
				product.ImagePath2 = File2.FileName;

			}
			if (File3 != null && File3.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File3.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File3.CopyToAsync(stream);
				}
				product.ImagePath3 = File3.FileName;

			}
			_context.Add(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductCategoryName", product.ProductCategoryId);
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName", product.ProductMainCategoryId);
            ViewData["ProductSubCategoryId"] = new SelectList(_context.ProductSubCategory, "ProductSubCategoryId", "ProductSubCategoryName", product.ProductSubCategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrunID,UrunAd,ImagePath,ImagePath2,ImagePath3,KisaAciklama,Aciklama,Vitrin,ProductMainCategoryId,ProductSubCategoryId,ProductCategoryId")] Product product, IFormFile File, IFormFile File2, IFormFile File3)
        {
            if (id != product.UrunID)
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
				product.ImagePath = File.FileName;
				
			}
			if (File2 != null && File2.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File2.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File2.CopyToAsync(stream);
				}
				product.ImagePath2 = File2.FileName;

			}
			if (File3 != null && File3.Length > 0)
			{
				// upload işlemi yapmak için konum belirle
				string path = Path.Combine(_environment.WebRootPath, "Uploads", File3.FileName);

				// uploads dizini yoksa oluştur
				if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Uploads")))
				{
					Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Uploads"));
				}

				// belirlenen konuma upload yapılır
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await File3.CopyToAsync(stream);
				}
				product.ImagePath3 = File3.FileName;

			}
			_context.Update(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductCategorys)
                .Include(p => p.ProductMainCategorys)
                .Include(p => p.ProductSubCategorys)
                .FirstOrDefaultAsync(m => m.UrunID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Product.Any(e => e.UrunID == id);
        }
    }
}
