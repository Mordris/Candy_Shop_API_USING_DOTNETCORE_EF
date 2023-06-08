using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandyShopAPI.Data;
using CandyShopAPI.Models.Domain;

namespace CandyShopAPI.Controllers
{
    public class DealersController : Controller
    {
        private readonly CandyShopDbContext _context;

        public DealersController(CandyShopDbContext context)
        {
            _context = context;
        }

        // GET: Dealers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Dealers.ToListAsync());
        }

        // GET: Dealers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealers == null)
            {
                return NotFound();
            }

            return View(dealers);
        }

        // GET: Dealers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone")] Dealers dealers)
        {
            if (ModelState.IsValid)
            {
                dealers.Id = Guid.NewGuid();
                _context.Add(dealers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealers);
        }

        // GET: Dealers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers.FindAsync(id);
            if (dealers == null)
            {
                return NotFound();
            }
            return View(dealers);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Address,Phone")] Dealers dealers)
        {
            if (id != dealers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealersExists(dealers.Id))
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
            return View(dealers);
        }

        // GET: Dealers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealers == null)
            {
                return NotFound();
            }

            return View(dealers);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Dealers == null)
            {
                return Problem("Entity set 'MVCDemoDbContext.Dealers'  is null.");
            }
            var dealers = await _context.Dealers.FindAsync(id);
            if (dealers != null)
            {
                _context.Dealers.Remove(dealers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealersExists(Guid id)
        {
          return _context.Dealers.Any(e => e.Id == id);
        }
    }
}
