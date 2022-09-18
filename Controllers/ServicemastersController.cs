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
    public class ServicemastersController : Controller
    {
        private readonly HospitalContext _context;

        public ServicemastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Servicemasters
        public async Task<IActionResult> Index()
        {
              return _context.Servicemasters != null ? 
                          View(await _context.Servicemasters.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Servicemasters'  is null.");
        }

        // GET: Servicemasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicemasters == null)
            {
                return NotFound();
            }

            var servicemaster = await _context.Servicemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicemaster == null)
            {
                return NotFound();
            }

            return View(servicemaster);
        }

        // GET: Servicemasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicemasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Service")] Servicemaster servicemaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicemaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicemaster);
        }

        // GET: Servicemasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicemasters == null)
            {
                return NotFound();
            }

            var servicemaster = await _context.Servicemasters.FindAsync(id);
            if (servicemaster == null)
            {
                return NotFound();
            }
            return View(servicemaster);
        }

        // POST: Servicemasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Service")] Servicemaster servicemaster)
        {
            if (id != servicemaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicemaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicemasterExists(servicemaster.Id))
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
            return View(servicemaster);
        }

        // GET: Servicemasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicemasters == null)
            {
                return NotFound();
            }

            var servicemaster = await _context.Servicemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicemaster == null)
            {
                return NotFound();
            }

            return View(servicemaster);
        }

        // POST: Servicemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicemasters == null)
            {
                return Problem("Entity set 'HospitalContext.Servicemasters'  is null.");
            }
            var servicemaster = await _context.Servicemasters.FindAsync(id);
            if (servicemaster != null)
            {
                _context.Servicemasters.Remove(servicemaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicemasterExists(int id)
        {
          return (_context.Servicemasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
