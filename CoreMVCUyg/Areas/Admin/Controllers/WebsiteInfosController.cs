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
    public class WebsiteInfosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebsiteInfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/WebsiteInfos
        public async Task<IActionResult> Index()
        {
              return View(await _context.WebsiteInfo.ToListAsync());
        }

        // GET: Admin/WebsiteInfos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WebsiteInfo == null)
            {
                return NotFound();
            }

            var websiteInfo = await _context.WebsiteInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (websiteInfo == null)
            {
                return NotFound();
            }

            return View(websiteInfo);
        }

        // GET: Admin/WebsiteInfos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WebsiteInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unvan,Slogan,CalismaSaat,Adres,Adres2,Telefon,Telefon2,Fax,EPosta,Facebook,Linkedin,Youtube,Instagram,GooglePlus,Twitter,GoogleMapLink,HakkimizdaFooterAciklama,Author,Designer,ContentLanguage,Robots,Charset,Distribution,Copyright,Abstract,Raiting,Classification,MetaTitle,MetaDescription,MetaKeywords")] WebsiteInfo websiteInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(websiteInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(websiteInfo);
        }

        // GET: Admin/WebsiteInfos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WebsiteInfo == null)
            {
                return NotFound();
            }

            var websiteInfo = await _context.WebsiteInfo.FindAsync(id);
            if (websiteInfo == null)
            {
                return NotFound();
            }
            return View(websiteInfo);
        }

        // POST: Admin/WebsiteInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unvan,Slogan,CalismaSaat,Adres,Adres2,Telefon,Telefon2,Fax,EPosta,Facebook,Linkedin,Youtube,Instagram,GooglePlus,Twitter,GoogleMapLink,HakkimizdaFooterAciklama,Author,Designer,ContentLanguage,Robots,Charset,Distribution,Copyright,Abstract,Raiting,Classification,MetaTitle,MetaDescription,MetaKeywords")] WebsiteInfo websiteInfo)
        {
            if (id != websiteInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(websiteInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteInfoExists(websiteInfo.Id))
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
            return View(websiteInfo);
        }

        // GET: Admin/WebsiteInfos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WebsiteInfo == null)
            {
                return NotFound();
            }

            var websiteInfo = await _context.WebsiteInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (websiteInfo == null)
            {
                return NotFound();
            }

            return View(websiteInfo);
        }

        // POST: Admin/WebsiteInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WebsiteInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WebsiteInfo'  is null.");
            }
            var websiteInfo = await _context.WebsiteInfo.FindAsync(id);
            if (websiteInfo != null)
            {
                _context.WebsiteInfo.Remove(websiteInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteInfoExists(int id)
        {
          return _context.WebsiteInfo.Any(e => e.Id == id);
        }
    }
}
