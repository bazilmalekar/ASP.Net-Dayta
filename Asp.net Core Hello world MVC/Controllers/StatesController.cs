using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.net_Core_Hello_world_MVC.Data;
using Asp.net_Core_Hello_world_MVC.Models;

namespace Asp.net_Core_Hello_world_MVC.Controllers
{
    public class StatesController : Controller
    {
        private readonly Hello_world_MVCDbContext _context;

        public StatesController(Hello_world_MVCDbContext context)
        {
            _context = context;
        }

        // GET: States
        public async Task<IActionResult> Index()
        {
              return _context.States != null ? 
                          View(await _context.States.ToListAsync()) :
                          Problem("Entity set 'Hello_world_MVCDbContext.States'  is null.");
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var states = await _context.States
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateCode,StateName")] States states)
        {
            if (ModelState.IsValid)
            {
                _context.Add(states);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(states);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var states = await _context.States.FindAsync(id);
            if (states == null)
            {
                return NotFound();
            }
            return View(states);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateId,StateCode,StateName")] States states)
        {
            if (id != states.StateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(states);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatesExists(states.StateId))
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
            return View(states);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var states = await _context.States
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.States == null)
            {
                return Problem("Entity set 'Hello_world_MVCDbContext.States'  is null.");
            }
            var states = await _context.States.FindAsync(id);
            if (states != null)
            {
                _context.States.Remove(states);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatesExists(int id)
        {
          return (_context.States?.Any(e => e.StateId == id)).GetValueOrDefault();
        }
    }
}
