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
    public class DepartmentmastersController : Controller
    {
        private readonly HospitalContext _context;

        public DepartmentmastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Departmentmasters
        public async Task<IActionResult> Index()
        {
              return _context.Departmentmasters != null ? 
                          View(await _context.Departmentmasters.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Departmentmasters'  is null.");
        }

        // GET: Departmentmasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departmentmasters == null)
            {
                return NotFound();
            }

            var departmentmaster = await _context.Departmentmasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentmaster == null)
            {
                return NotFound();
            }

            return View(departmentmaster);
        }

        // GET: Departmentmasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departmentmasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departmentmaster departmentmaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentmaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentmaster);
        }

        // GET: Departmentmasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departmentmasters == null)
            {
                return NotFound();
            }

            var departmentmaster = await _context.Departmentmasters.FindAsync(id);
            if (departmentmaster == null)
            {
                return NotFound();
            }
            return View(departmentmaster);
        }

        // POST: Departmentmasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departmentmaster departmentmaster)
        {
            if (id != departmentmaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentmaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentmasterExists(departmentmaster.Id))
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
            return View(departmentmaster);
        }

        // GET: Departmentmasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departmentmasters == null)
            {
                return NotFound();
            }

            var departmentmaster = await _context.Departmentmasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentmaster == null)
            {
                return NotFound();
            }

            return View(departmentmaster);
        }

        // POST: Departmentmasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departmentmasters == null)
            {
                return Problem("Entity set 'HospitalContext.Departmentmasters'  is null.");
            }
            var departmentmaster = await _context.Departmentmasters.FindAsync(id);
            if (departmentmaster != null)
            {
                _context.Departmentmasters.Remove(departmentmaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentmasterExists(int id)
        {
          return (_context.Departmentmasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
