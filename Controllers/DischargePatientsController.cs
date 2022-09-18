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
    public class DischargePatientsController : Controller
    {
        private readonly HospitalContext _context;

        public DischargePatientsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: DischargePatients
        public async Task<IActionResult> Index()
        {
              return _context.DischargePatients != null ? 
                          View(await _context.DischargePatients.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.DischargePatients'  is null.");
        }

        // GET: DischargePatients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DischargePatients == null)
            {
                return NotFound();
            }

            var dischargePatient = await _context.DischargePatients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dischargePatient == null)
            {
                return NotFound();
            }

            return View(dischargePatient);
        }

        // GET: DischargePatients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DischargePatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,PatientName,InPatient,OutPatient")] DischargePatient dischargePatient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dischargePatient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dischargePatient);
        }

        // GET: DischargePatients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DischargePatients == null)
            {
                return NotFound();
            }

            var dischargePatient = await _context.DischargePatients.FindAsync(id);
            if (dischargePatient == null)
            {
                return NotFound();
            }
            return View(dischargePatient);
        }

        // POST: DischargePatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,PatientName,InPatient,OutPatient")] DischargePatient dischargePatient)
        {
            if (id != dischargePatient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dischargePatient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DischargePatientExists(dischargePatient.Id))
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
            return View(dischargePatient);
        }

        // GET: DischargePatients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DischargePatients == null)
            {
                return NotFound();
            }

            var dischargePatient = await _context.DischargePatients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dischargePatient == null)
            {
                return NotFound();
            }

            return View(dischargePatient);
        }

        // POST: DischargePatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DischargePatients == null)
            {
                return Problem("Entity set 'HospitalContext.DischargePatients'  is null.");
            }
            var dischargePatient = await _context.DischargePatients.FindAsync(id);
            if (dischargePatient != null)
            {
                _context.DischargePatients.Remove(dischargePatient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DischargePatientExists(int id)
        {
          return (_context.DischargePatients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
