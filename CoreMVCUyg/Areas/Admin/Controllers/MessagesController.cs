﻿using System;
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
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        public async Task<IActionResult> Index()
        {
              return View(await _context.Message.ToListAsync());
        }

        // GET: Admin/Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Admin/Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Subject,Phone,Messages,GetDateTime")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Admin/Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Admin/Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Subject,Phone,Messages,GetDateTime")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            return View(message);
        }

        // GET: Admin/Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Admin/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Message == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Message'  is null.");
            }
            var message = await _context.Message.FindAsync(id);
            if (message != null)
            {
                _context.Message.Remove(message);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
          return _context.Message.Any(e => e.Id == id);
        }
    }
}
