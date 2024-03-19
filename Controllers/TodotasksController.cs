using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudemvccore.Data;
using crudemvccore.Models;

namespace crudemvccore.Controllers
{
    public class TodotasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodotasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Todotasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todotasks.ToListAsync());
        }

        // GET: Todotasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotask = await _context.Todotasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todotask == null)
            {
                return NotFound();
            }

            return View(todotask);
        }

        // GET: Todotasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todotasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsComplete")] Todotask todotask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todotask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todotask);
        }

        // GET: Todotasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotask = await _context.Todotasks.FindAsync(id);
            if (todotask == null)
            {
                return NotFound();
            }
            return View(todotask);
        }

        // POST: Todotasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsComplete")] Todotask todotask)
        {
            if (id != todotask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todotask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodotaskExists(todotask.Id))
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
            return View(todotask);
        }

        // GET: Todotasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotask = await _context.Todotasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todotask == null)
            {
                return NotFound();
            }

            return View(todotask);
        }

        // POST: Todotasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todotask = await _context.Todotasks.FindAsync(id);
            if (todotask != null)
            {
                _context.Todotasks.Remove(todotask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodotaskExists(int id)
        {
            return _context.Todotasks.Any(e => e.Id == id);
        }
    }
}
