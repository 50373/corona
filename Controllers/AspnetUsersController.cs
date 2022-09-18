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
    public class AspnetUsersController : Controller
    {
        private readonly HospitalContext _context;

        public AspnetUsersController(HospitalContext context)
        {
            _context = context;
        }

        // GET: AspnetUsers
        public async Task<IActionResult> Index()
        {
              return _context.AspnetUser != null ? 
                          View(await _context.AspnetUser.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.AspnetUser'  is null.");
        }

        // GET: AspnetUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AspnetUser == null)
            {
                return NotFound();
            }

            var aspnetUser = await _context.AspnetUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspnetUser == null)
            {
                return NotFound();
            }

            return View(aspnetUser);
        }

        // GET: AspnetUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspnetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Gender,Age,MobileNumber")] AspnetUser aspnetUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspnetUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspnetUser);
        }

        // GET: AspnetUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AspnetUser == null)
            {
                return NotFound();
            }

            var aspnetUser = await _context.AspnetUser.FindAsync(id);
            if (aspnetUser == null)
            {
                return NotFound();
            }
            return View(aspnetUser);
        }

        // POST: AspnetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Gender,Age,MobileNumber")] AspnetUser aspnetUser)
        {
            if (id != aspnetUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspnetUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspnetUserExists(aspnetUser.Id))
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
            return View(aspnetUser);
        }

        // GET: AspnetUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AspnetUser == null)
            {
                return NotFound();
            }

            var aspnetUser = await _context.AspnetUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspnetUser == null)
            {
                return NotFound();
            }

            return View(aspnetUser);
        }

        // POST: AspnetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AspnetUser == null)
            {
                return Problem("Entity set 'HospitalContext.AspnetUser'  is null.");
            }
            var aspnetUser = await _context.AspnetUser.FindAsync(id);
            if (aspnetUser != null)
            {
                _context.AspnetUser.Remove(aspnetUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspnetUserExists(int id)
        {
          return (_context.AspnetUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
