using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Views
{
    [Area("Admin")]
    [Authorize]
    public class DatabaseTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatabaseTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatabaseTechnologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatabaseTechnology.ToListAsync());
        }

        // GET: DatabaseTechnologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseTechnology = await _context.DatabaseTechnology
                .FirstOrDefaultAsync(m => m.DatabaseTechnologyId == id);
            if (databaseTechnology == null)
            {
                return NotFound();
            }

            return View(databaseTechnology);
        }

        // GET: DatabaseTechnologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatabaseTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatabaseTechnologyId,DatabaseTechnologyName")] DatabaseTechnology databaseTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(databaseTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(databaseTechnology);
        }

        // GET: DatabaseTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseTechnology = await _context.DatabaseTechnology.FindAsync(id);
            if (databaseTechnology == null)
            {
                return NotFound();
            }
            return View(databaseTechnology);
        }

        // POST: DatabaseTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatabaseTechnologyId,DatabaseTechnologyName")] DatabaseTechnology databaseTechnology)
        {
            if (id != databaseTechnology.DatabaseTechnologyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(databaseTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatabaseTechnologyExists(databaseTechnology.DatabaseTechnologyId))
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
            return View(databaseTechnology);
        }

        // GET: DatabaseTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseTechnology = await _context.DatabaseTechnology
                .FirstOrDefaultAsync(m => m.DatabaseTechnologyId == id);
            if (databaseTechnology == null)
            {
                return NotFound();
            }

            return View(databaseTechnology);
        }

        // POST: DatabaseTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var databaseTechnology = await _context.DatabaseTechnology.FindAsync(id);
            _context.DatabaseTechnology.Remove(databaseTechnology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatabaseTechnologyExists(int id)
        {
            return _context.DatabaseTechnology.Any(e => e.DatabaseTechnologyId == id);
        }
    }
}
