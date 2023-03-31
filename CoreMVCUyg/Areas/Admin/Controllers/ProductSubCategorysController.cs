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
    public class ProductSubCategorysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSubCategorysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductSubCategorys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductSubCategory.Include(p => p.ProductMainCategorys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProductSubCategorys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductSubCategory == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .Include(p => p.ProductMainCategorys)
                .FirstOrDefaultAsync(m => m.ProductSubCategoryId == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // GET: Admin/ProductSubCategorys/Create
        public IActionResult Create()
        {
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName");
            return View();
        }

        // POST: Admin/ProductSubCategorys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSubCategoryId,ProductSubCategoryName,Order,ProductMainCategoryId")] ProductSubCategory productSubCategory)
        {
                _context.Add(productSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Admin/ProductSubCategorys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductSubCategory == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName", productSubCategory.ProductMainCategoryId);
            return View(productSubCategory);
        }

        // POST: Admin/ProductSubCategorys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSubCategoryId,ProductSubCategoryName,Order,ProductMainCategoryId")] ProductSubCategory productSubCategory)
        {
                    _context.Update(productSubCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
        }
          
        

        // GET: Admin/ProductSubCategorys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductSubCategory == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .Include(p => p.ProductMainCategorys)
                .FirstOrDefaultAsync(m => m.ProductSubCategoryId == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // POST: Admin/ProductSubCategorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductSubCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductSubCategory'  is null.");
            }
            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            if (productSubCategory != null)
            {
                _context.ProductSubCategory.Remove(productSubCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubCategoryExists(int id)
        {
          return _context.ProductSubCategory.Any(e => e.ProductSubCategoryId == id);
        }
    }
}
