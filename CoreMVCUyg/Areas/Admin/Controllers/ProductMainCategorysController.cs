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
    public class ProductMainCategorysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductMainCategorysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductMainCategorys
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProductMainCategory.ToListAsync());
        }

        // GET: Admin/ProductMainCategorys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductMainCategory == null)
            {
                return NotFound();
            }

            var productMainCategory = await _context.ProductMainCategory
                .FirstOrDefaultAsync(m => m.ProductMainCategoryId == id);
            if (productMainCategory == null)
            {
                return NotFound();
            }

            return View(productMainCategory);
        }

        // GET: Admin/ProductMainCategorys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductMainCategorys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductMainCategoryId,ProductMainCategoryName,Order")] ProductMainCategory productMainCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMainCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMainCategory);
        }

        // GET: Admin/ProductMainCategorys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductMainCategory == null)
            {
                return NotFound();
            }

            var productMainCategory = await _context.ProductMainCategory.FindAsync(id);
            if (productMainCategory == null)
            {
                return NotFound();
            }
            return View(productMainCategory);
        }

        // POST: Admin/ProductMainCategorys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductMainCategoryId,ProductMainCategoryName,Order")] ProductMainCategory productMainCategory)
        {
            if (id != productMainCategory.ProductMainCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMainCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMainCategoryExists(productMainCategory.ProductMainCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productMainCategory);
        }

        // GET: Admin/ProductMainCategorys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductMainCategory == null)
            {
                return NotFound();
            }

            var productMainCategory = await _context.ProductMainCategory
                .FirstOrDefaultAsync(m => m.ProductMainCategoryId == id);
            if (productMainCategory == null)
            {
                return NotFound();
            }

            return View(productMainCategory);
        }

        // POST: Admin/ProductMainCategorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductMainCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductMainCategory'  is null.");
            }
            var productMainCategory = await _context.ProductMainCategory.FindAsync(id);
            if (productMainCategory != null)
            {
                _context.ProductMainCategory.Remove(productMainCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMainCategoryExists(int id)
        {
          return _context.ProductMainCategory.Any(e => e.ProductMainCategoryId == id);
        }
    }
}
