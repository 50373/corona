using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class RoommastersController : Controller
    {
        private readonly HospitalContext _context;

        public RoommastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Roommasters
        public async Task<IActionResult> Index()
        {
              return _context.Roommasters != null ? 
                          View(await _context.Roommasters.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Roommasters'  is null.");
        }

        // GET: Roommasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Roommasters == null)
            {
                return NotFound();
            }

            var roommaster = await _context.Roommasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roommaster == null)
            {
                return NotFound();
            }

            return View(roommaster);
        }

        // GET: Roommasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roommasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] Roommaster roommaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roommaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roommaster);
        }

        // GET: Roommasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Roommasters == null)
            {
                return NotFound();
            }

            var roommaster = await _context.Roommasters.FindAsync(id);
            if (roommaster == null)
            {
                return NotFound();
            }
            return View(roommaster);
        }

        // POST: Roommasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] Roommaster roommaster)
        {
            if (id != roommaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roommaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoommasterExists(roommaster.Id))
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
            return View(roommaster);
        }

        // GET: Roommasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roommasters == null)
            {
                return NotFound();
            }

            var roommaster = await _context.Roommasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roommaster == null)
            {
                return NotFound();
            }

            return View(roommaster);
        }

        // POST: Roommasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Roommasters == null)
            {
                return Problem("Entity set 'HospitalContext.Roommasters'  is null.");
            }
            var roommaster = await _context.Roommasters.FindAsync(id);
            if (roommaster != null)
            {
                _context.Roommasters.Remove(roommaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoommasterExists(int id)
        {
          return (_context.Roommasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
