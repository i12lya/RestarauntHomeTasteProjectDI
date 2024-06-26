﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestarauntHomeTaste.Data;

namespace RestarauntHomeTaste.Controllers
{
    public class DishTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DishTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DishTypes.ToListAsync());
        }

        // GET: DishTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishType = await _context.DishTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishType == null)
            {
                return NotFound();
            }

            return View(dishType);
        }

        // GET: DishTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DishTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateModified")] DishType dishType)
        {
            if (ModelState.IsValid)
            {
                dishType.DateModified = DateTime.Now;
                _context.DishTypes.Add(dishType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dishType);
        }

        // GET: DishTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishType = await _context.DishTypes.FindAsync(id);
            if (dishType == null)
            {
                return NotFound();
            }
            return View(dishType);
        }

        // POST: DishTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateModified")] DishType dishType)
        {
            if (id != dishType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dishType.DateModified = DateTime.Now;
                    _context.DishTypes.Update(dishType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishTypeExists(dishType.Id))
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
            return View(dishType);
        }

        // GET: DishTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishType = await _context.DishTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishType == null)
            {
                return NotFound();
            }

            return View(dishType);
        }

        // POST: DishTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dishType = await _context.DishTypes.FindAsync(id);
            if (dishType != null)
            {
                _context.DishTypes.Remove(dishType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishTypeExists(int id)
        {
            return _context.DishTypes.Any(e => e.Id == id);
        }
    }
}
