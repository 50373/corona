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
    public class MedicinemastersController : Controller
    {
        private readonly HospitalContext _context;

        public MedicinemastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Medicinemasters
        public async Task<IActionResult> Index()
        {
              return _context.Medicinemasters != null ? 
                          View(await _context.Medicinemasters.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Medicinemasters'  is null.");
        }

        // GET: Medicinemasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicinemasters == null)
            {
                return NotFound();
            }

            var medicinemaster = await _context.Medicinemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicinemaster == null)
            {
                return NotFound();
            }

            return View(medicinemaster);
        }

        // GET: Medicinemasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicinemasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Expiry")] Medicinemaster medicinemaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicinemaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicinemaster);
        }

        // GET: Medicinemasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicinemasters == null)
            {
                return NotFound();
            }

            var medicinemaster = await _context.Medicinemasters.FindAsync(id);
            if (medicinemaster == null)
            {
                return NotFound();
            }
            return View(medicinemaster);
        }

        // POST: Medicinemasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Expiry")] Medicinemaster medicinemaster)
        {
            if (id != medicinemaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicinemaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicinemasterExists(medicinemaster.Id))
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
            return View(medicinemaster);
        }

        // GET: Medicinemasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicinemasters == null)
            {
                return NotFound();
            }

            var medicinemaster = await _context.Medicinemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicinemaster == null)
            {
                return NotFound();
            }

            return View(medicinemaster);
        }

        // POST: Medicinemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicinemasters == null)
            {
                return Problem("Entity set 'HospitalContext.Medicinemasters'  is null.");
            }
            var medicinemaster = await _context.Medicinemasters.FindAsync(id);
            if (medicinemaster != null)
            {
                _context.Medicinemasters.Remove(medicinemaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicinemasterExists(int id)
        {
          return (_context.Medicinemasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
