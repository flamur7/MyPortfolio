using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Views
{
    public class BackEndTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackEndTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BackEndTechnologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.BackEndTechnology.ToListAsync());
        }

        // GET: BackEndTechnologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backEndTechnology = await _context.BackEndTechnology
                .FirstOrDefaultAsync(m => m.BackEndTechnologyId == id);
            if (backEndTechnology == null)
            {
                return NotFound();
            }

            return View(backEndTechnology);
        }

        // GET: BackEndTechnologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BackEndTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BackEndTechnologyId,BackEndTechnologyName")] BackEndTechnology backEndTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backEndTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backEndTechnology);
        }

        // GET: BackEndTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backEndTechnology = await _context.BackEndTechnology.FindAsync(id);
            if (backEndTechnology == null)
            {
                return NotFound();
            }
            return View(backEndTechnology);
        }

        // POST: BackEndTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BackEndTechnologyId,BackEndTechnologyName")] BackEndTechnology backEndTechnology)
        {
            if (id != backEndTechnology.BackEndTechnologyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(backEndTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackEndTechnologyExists(backEndTechnology.BackEndTechnologyId))
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
            return View(backEndTechnology);
        }

        // GET: BackEndTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backEndTechnology = await _context.BackEndTechnology
                .FirstOrDefaultAsync(m => m.BackEndTechnologyId == id);
            if (backEndTechnology == null)
            {
                return NotFound();
            }

            return View(backEndTechnology);
        }

        // POST: BackEndTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var backEndTechnology = await _context.BackEndTechnology.FindAsync(id);
            _context.BackEndTechnology.Remove(backEndTechnology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackEndTechnologyExists(int id)
        {
            return _context.BackEndTechnology.Any(e => e.BackEndTechnologyId == id);
        }
    }
}
