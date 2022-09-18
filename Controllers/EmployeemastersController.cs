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
    public class EmployeemastersController : Controller
    {
        private readonly HospitalContext _context;

        public EmployeemastersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Employeemasters
        public async Task<IActionResult> Index()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.Employees'  is null.");
        }

        // GET: Employeemasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeemaster = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeemaster == null)
            {
                return NotFound();
            }

            return View(employeemaster);
        }

        // GET: Employeemasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeemasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,Designation")] Employeemaster employeemaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeemaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeemaster);
        }

        // GET: Employeemasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeemaster = await _context.Employees.FindAsync(id);
            if (employeemaster == null)
            {
                return NotFound();
            }
            return View(employeemaster);
        }

        // POST: Employeemasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Gender,Designation")] Employeemaster employeemaster)
        {
            if (id != employeemaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeemaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeemasterExists(employeemaster.Id))
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
            return View(employeemaster);
        }

        // GET: Employeemasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employeemaster = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeemaster == null)
            {
                return NotFound();
            }

            return View(employeemaster);
        }

        // POST: Employeemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'HospitalContext.Employees'  is null.");
            }
            var employeemaster = await _context.Employees.FindAsync(id);
            if (employeemaster != null)
            {
                _context.Employees.Remove(employeemaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeemasterExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
