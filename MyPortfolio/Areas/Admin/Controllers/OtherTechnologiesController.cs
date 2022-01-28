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
    public class OtherTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OtherTechnologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.OtherTechnology.ToListAsync());
        }

        // GET: OtherTechnologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherTechnology = await _context.OtherTechnology
                .FirstOrDefaultAsync(m => m.OtherTechnologyId == id);
            if (otherTechnology == null)
            {
                return NotFound();
            }

            return View(otherTechnology);
        }

        // GET: OtherTechnologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OtherTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OtherTechnologyId,OtherTechnologyName")] OtherTechnology otherTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otherTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(otherTechnology);
        }

        // GET: OtherTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherTechnology = await _context.OtherTechnology.FindAsync(id);
            if (otherTechnology == null)
            {
                return NotFound();
            }
            return View(otherTechnology);
        }

        // POST: OtherTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OtherTechnologyId,OtherTechnologyName")] OtherTechnology otherTechnology)
        {
            if (id != otherTechnology.OtherTechnologyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherTechnologyExists(otherTechnology.OtherTechnologyId))
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
            return View(otherTechnology);
        }

        // GET: OtherTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherTechnology = await _context.OtherTechnology
                .FirstOrDefaultAsync(m => m.OtherTechnologyId == id);
            if (otherTechnology == null)
            {
                return NotFound();
            }

            return View(otherTechnology);
        }

        // POST: OtherTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otherTechnology = await _context.OtherTechnology.FindAsync(id);
            _context.OtherTechnology.Remove(otherTechnology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherTechnologyExists(int id)
        {
            return _context.OtherTechnology.Any(e => e.OtherTechnologyId == id);
        }
    }
}
