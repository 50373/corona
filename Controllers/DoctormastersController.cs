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
    public class DoctormastersController : Controller
    {
        private readonly HospitalContext _context;

        public DoctormastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Doctormasters
        public async Task<IActionResult> Index()
        {
              return _context.Doctormasters != null ? 
                          View(await _context.Doctormasters.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Doctormasters'  is null.");
        }

        // GET: Doctormasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctormasters == null)
            {
                return NotFound();
            }

            var doctormaster = await _context.Doctormasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctormaster == null)
            {
                return NotFound();
            }

            return View(doctormaster);
        }

        // GET: Doctormasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctormasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specilization,Gender,Active")] Doctormaster doctormaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctormaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctormaster);
        }

        // GET: Doctormasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctormasters == null)
            {
                return NotFound();
            }

            var doctormaster = await _context.Doctormasters.FindAsync(id);
            if (doctormaster == null)
            {
                return NotFound();
            }
            return View(doctormaster);
        }

        // POST: Doctormasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specilization,Gender,Active")] Doctormaster doctormaster)
        {
            if (id != doctormaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctormaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctormasterExists(doctormaster.Id))
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
            return View(doctormaster);
        }

        // GET: Doctormasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctormasters == null)
            {
                return NotFound();
            }

            var doctormaster = await _context.Doctormasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctormaster == null)
            {
                return NotFound();
            }

            return View(doctormaster);
        }

        // POST: Doctormasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctormasters == null)
            {
                return Problem("Entity set 'HospitalContext.Doctormasters'  is null.");
            }
            var doctormaster = await _context.Doctormasters.FindAsync(id);
            if (doctormaster != null)
            {
                _context.Doctormasters.Remove(doctormaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctormasterExists(int id)
        {
          return (_context.Doctormasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
