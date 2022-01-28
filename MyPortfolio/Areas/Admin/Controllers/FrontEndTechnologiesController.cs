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
    public class FrontEndTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrontEndTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FrontEndTechnologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrontEndTechnology.ToListAsync());
        }

        // GET: FrontEndTechnologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontEndTechnology = await _context.FrontEndTechnology
                .FirstOrDefaultAsync(m => m.FrontEndTechnologyId == id);
            if (frontEndTechnology == null)
            {
                return NotFound();
            }

            return View(frontEndTechnology);
        }

        // GET: FrontEndTechnologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrontEndTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrontEndTechnologyId,FrontEndName")] FrontEndTechnology frontEndTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frontEndTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frontEndTechnology);
        }

        // GET: FrontEndTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontEndTechnology = await _context.FrontEndTechnology.FindAsync(id);
            if (frontEndTechnology == null)
            {
                return NotFound();
            }
            return View(frontEndTechnology);
        }

        // POST: FrontEndTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrontEndTechnologyId,FrontEndName")] FrontEndTechnology frontEndTechnology)
        {
            if (id != frontEndTechnology.FrontEndTechnologyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frontEndTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrontEndTechnologyExists(frontEndTechnology.FrontEndTechnologyId))
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
            return View(frontEndTechnology);
        }

        // GET: FrontEndTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontEndTechnology = await _context.FrontEndTechnology
                .FirstOrDefaultAsync(m => m.FrontEndTechnologyId == id);
            if (frontEndTechnology == null)
            {
                return NotFound();
            }

            return View(frontEndTechnology);
        }

        // POST: FrontEndTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frontEndTechnology = await _context.FrontEndTechnology.FindAsync(id);
            _context.FrontEndTechnology.Remove(frontEndTechnology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrontEndTechnologyExists(int id)
        {
            return _context.FrontEndTechnology.Any(e => e.FrontEndTechnologyId == id);
        }
    }
}
