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
    public class CollaboratorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollaboratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collaborators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Collaborators.Include(c => c.BackEndTechnology).Include(c => c.DatabaseTechnology).Include(c => c.FrontEndTechnology).Include(c => c.OtherTechnology);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Collaborators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborators = await _context.Collaborators
                .Include(c => c.BackEndTechnology)
                .Include(c => c.DatabaseTechnology)
                .Include(c => c.FrontEndTechnology)
                .Include(c => c.OtherTechnology)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborators == null)
            {
                return NotFound();
            }

            return View(collaborators);
        }

        // GET: Collaborators/Create
        public IActionResult Create()
        {
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId");
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.Set<DatabaseTechnology>(), "DatabaseTechnologyId", "DatabaseTechnologyId");
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.Set<FrontEndTechnology>(), "FrontEndTechnologyId", "FrontEndTechnologyId");
            ViewData["OtherTechnologyId"] = new SelectList(_context.Set<OtherTechnology>(), "OtherTechnologyId", "OtherTechnologyId");
            return View();
        }

        // POST: Collaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaboratorId,CollaboratorFullName,BackEndTechnologyId,FrontEndTechnologyId,OtherTechnologyId,DatabaseTechnologyId")] Collaborators collaborators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", collaborators.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.Set<DatabaseTechnology>(), "DatabaseTechnologyId", "DatabaseTechnologyId", collaborators.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.Set<FrontEndTechnology>(), "FrontEndTechnologyId", "FrontEndTechnologyId", collaborators.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.Set<OtherTechnology>(), "OtherTechnologyId", "OtherTechnologyId", collaborators.OtherTechnologyId);
            return View(collaborators);
        }

        // GET: Collaborators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborators = await _context.Collaborators.FindAsync(id);
            if (collaborators == null)
            {
                return NotFound();
            }
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", collaborators.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.Set<DatabaseTechnology>(), "DatabaseTechnologyId", "DatabaseTechnologyId", collaborators.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.Set<FrontEndTechnology>(), "FrontEndTechnologyId", "FrontEndTechnologyId", collaborators.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.Set<OtherTechnology>(), "OtherTechnologyId", "OtherTechnologyId", collaborators.OtherTechnologyId);
            return View(collaborators);
        }

        // POST: Collaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorId,CollaboratorFullName,BackEndTechnologyId,FrontEndTechnologyId,OtherTechnologyId,DatabaseTechnologyId")] Collaborators collaborators)
        {
            if (id != collaborators.CollaboratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorsExists(collaborators.CollaboratorId))
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
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", collaborators.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.Set<DatabaseTechnology>(), "DatabaseTechnologyId", "DatabaseTechnologyId", collaborators.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.Set<FrontEndTechnology>(), "FrontEndTechnologyId", "FrontEndTechnologyId", collaborators.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.Set<OtherTechnology>(), "OtherTechnologyId", "OtherTechnologyId", collaborators.OtherTechnologyId);
            return View(collaborators);
        }

        // GET: Collaborators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborators = await _context.Collaborators
                .Include(c => c.BackEndTechnology)
                .Include(c => c.DatabaseTechnology)
                .Include(c => c.FrontEndTechnology)
                .Include(c => c.OtherTechnology)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborators == null)
            {
                return NotFound();
            }

            return View(collaborators);
        }

        // POST: Collaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborators = await _context.Collaborators.FindAsync(id);
            _context.Collaborators.Remove(collaborators);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaboratorsExists(int id)
        {
            return _context.Collaborators.Any(e => e.CollaboratorId == id);
        }
    }
}
