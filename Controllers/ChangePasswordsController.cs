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
    public class ChangePasswordsController : Controller
    {
        private readonly HospitalContext _context;

        public ChangePasswordsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: ChangePasswords
        public async Task<IActionResult> Index()
        {
              return _context.ChangePassword != null ? 
                          View(await _context.ChangePassword.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.ChangePassword'  is null.");
        }

        // GET: ChangePasswords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChangePassword == null)
            {
                return NotFound();
            }

            var changePassword = await _context.ChangePassword
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changePassword == null)
            {
                return NotFound();
            }

            return View(changePassword);
        }

        // GET: ChangePasswords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChangePasswords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NewPassword,ConfirmPassword,RememberMe")] ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changePassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(changePassword);
        }

        // GET: ChangePasswords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChangePassword == null)
            {
                return NotFound();
            }

            var changePassword = await _context.ChangePassword.FindAsync(id);
            if (changePassword == null)
            {
                return NotFound();
            }
            return View(changePassword);
        }

        // POST: ChangePasswords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,NewPassword,ConfirmPassword,RememberMe")] ChangePassword changePassword)
        {
            if (id != changePassword.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(changePassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangePasswordExists(changePassword.Id))
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
            return View(changePassword);
        }

        // GET: ChangePasswords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChangePassword == null)
            {
                return NotFound();
            }

            var changePassword = await _context.ChangePassword
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changePassword == null)
            {
                return NotFound();
            }

            return View(changePassword);
        }

        // POST: ChangePasswords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChangePassword == null)
            {
                return Problem("Entity set 'HospitalContext.ChangePassword'  is null.");
            }
            var changePassword = await _context.ChangePassword.FindAsync(id);
            if (changePassword != null)
            {
                _context.ChangePassword.Remove(changePassword);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangePasswordExists(string id)
        {
          return (_context.ChangePassword?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
