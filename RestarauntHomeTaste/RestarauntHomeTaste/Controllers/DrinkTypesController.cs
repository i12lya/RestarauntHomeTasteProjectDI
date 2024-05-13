using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestarauntHomeTaste.Data;

namespace RestarauntHomeTaste.Controllers
{
    public class DrinkTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrinkTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DrinkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrinkTypes.ToListAsync());
        }

        // GET: DrinkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkType = await _context.DrinkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drinkType == null)
            {
                return NotFound();
            }

            return View(drinkType);
        }

        // GET: DrinkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrinkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateModified")] DrinkType drinkType)
        {
            if (ModelState.IsValid)
            {
                drinkType.DateModified = DateTime.Now;
                _context.DrinkTypes.Add(drinkType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drinkType);
        }

        // GET: DrinkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkType = await _context.DrinkTypes.FindAsync(id);
            if (drinkType == null)
            {
                return NotFound();
            }
            return View(drinkType);
        }

        // POST: DrinkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateModified")] DrinkType drinkType)
        {
            if (id != drinkType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    drinkType.DateModified = DateTime.Now;
                    _context.DrinkTypes.Update(drinkType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkTypeExists(drinkType.Id))
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
            return View(drinkType);
        }

        // GET: DrinkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkType = await _context.DrinkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drinkType == null)
            {
                return NotFound();
            }

            return View(drinkType);
        }

        // POST: DrinkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drinkType = await _context.DrinkTypes.FindAsync(id);
            if (drinkType != null)
            {
                _context.DrinkTypes.Remove(drinkType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkTypeExists(int id)
        {
            return _context.DrinkTypes.Any(e => e.Id == id);
        }
    }
}
