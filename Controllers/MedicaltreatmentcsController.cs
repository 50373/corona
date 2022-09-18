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
    public class MedicaltreatmentcsController : Controller
    {
        private readonly HospitalContext _context;

        public MedicaltreatmentcsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Medicaltreatmentcs
        public async Task<IActionResult> Index()
        {
              return _context.Medicaltreatmentcs != null ? 
                          View(await _context.Medicaltreatmentcs.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Medicaltreatmentcs'  is null.");
        }

        // GET: Medicaltreatmentcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicaltreatmentcs == null)
            {
                return NotFound();
            }

            var medicaltreatmentcs = await _context.Medicaltreatmentcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicaltreatmentcs == null)
            {
                return NotFound();
            }

            return View(medicaltreatmentcs);
        }

        // GET: Medicaltreatmentcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicaltreatmentcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Medicaltreatmentcs medicaltreatmentcs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicaltreatmentcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicaltreatmentcs);
        }

        // GET: Medicaltreatmentcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicaltreatmentcs == null)
            {
                return NotFound();
            }

            var medicaltreatmentcs = await _context.Medicaltreatmentcs.FindAsync(id);
            if (medicaltreatmentcs == null)
            {
                return NotFound();
            }
            return View(medicaltreatmentcs);
        }

        // POST: Medicaltreatmentcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Medicaltreatmentcs medicaltreatmentcs)
        {
            if (id != medicaltreatmentcs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicaltreatmentcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicaltreatmentcsExists(medicaltreatmentcs.Id))
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
            return View(medicaltreatmentcs);
        }

        // GET: Medicaltreatmentcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicaltreatmentcs == null)
            {
                return NotFound();
            }

            var medicaltreatmentcs = await _context.Medicaltreatmentcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicaltreatmentcs == null)
            {
                return NotFound();
            }

            return View(medicaltreatmentcs);
        }

        // POST: Medicaltreatmentcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicaltreatmentcs == null)
            {
                return Problem("Entity set 'HospitalContext.Medicaltreatmentcs'  is null.");
            }
            var medicaltreatmentcs = await _context.Medicaltreatmentcs.FindAsync(id);
            if (medicaltreatmentcs != null)
            {
                _context.Medicaltreatmentcs.Remove(medicaltreatmentcs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicaltreatmentcsExists(int id)
        {
          return (_context.Medicaltreatmentcs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
