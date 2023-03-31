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
    public class ProductCategorysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategorysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductCategorys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductCategory.Include(p => p.ProductMainCategorys).Include(p => p.ProductSubCategorys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProductCategorys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .Include(p => p.ProductMainCategorys)
                .Include(p => p.ProductSubCategorys)
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: Admin/ProductCategorys/Create
        public IActionResult Create()
        {
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName");
            ViewData["ProductSubCategoryId"] = new SelectList(_context.ProductSubCategory, "ProductSubCategoryId", "ProductSubCategoryName");
            return View();
        }

        // POST: Admin/ProductCategorys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCategoryId,ProductCategoryName,Order,ProductMainCategoryId,ProductSubCategoryId")] ProductCategory productCategory)
        {       
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Admin/ProductCategorys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            ViewData["ProductMainCategoryId"] = new SelectList(_context.ProductMainCategory, "ProductMainCategoryId", "ProductMainCategoryName", productCategory.ProductMainCategoryId);
            ViewData["ProductSubCategoryId"] = new SelectList(_context.ProductSubCategory, "ProductSubCategoryId", "ProductSubCategoryName", productCategory.ProductSubCategoryId);
            return View(productCategory);
        }

        // POST: Admin/ProductCategorys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCategoryId,ProductCategoryName,Order,ProductMainCategoryId,ProductSubCategoryId")] ProductCategory productCategory)
        {
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
        }

        // GET: Admin/ProductCategorys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .Include(p => p.ProductMainCategorys)
                .Include(p => p.ProductSubCategorys)
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: Admin/ProductCategorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductCategory'  is null.");
            }
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory != null)
            {
                _context.ProductCategory.Remove(productCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
          return _context.ProductCategory.Any(e => e.ProductCategoryId == id);
        }
    }
}
