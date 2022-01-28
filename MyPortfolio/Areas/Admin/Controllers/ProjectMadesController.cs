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
    public class ProjectMadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectMadesController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: ProjectMades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectMade.Include(p => p.BackEndTechnology).Include(p => p.DatabaseTechnology).Include(p => p.FrontEndTechnology).Include(p => p.OtherTechnology);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectMades
        public async Task<IActionResult> UserIndex()
        {
            var applicationDbContext = _context.ProjectMade.Include(p => p.BackEndTechnology).Include(p => p.DatabaseTechnology).Include(p => p.FrontEndTechnology).Include(p => p.OtherTechnology);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectMades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMade
                .Include(p => p.BackEndTechnology)
                .Include(p => p.DatabaseTechnology)
                .Include(p => p.FrontEndTechnology)
                .Include(p => p.OtherTechnology)
                .FirstOrDefaultAsync(m => m.ProjectMadeId == id);
            if (projectMade == null)
            {
                return NotFound();
            }

            return View(projectMade);
        }

        // GET: ProjectMades/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyName");
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyName");
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndName");
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyName");
            return View();
        }

        // POST: ProjectMades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectMadeId,ProjectMadeName,ProjectMadeDescription,BackEndTechnologyId,FrontEndTechnologyId,OtherTechnologyId,DatabaseTechnologyId")] ProjectMade projectMade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectMade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyName", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyName", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndName", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyName", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // GET: ProjectMades/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMade.FindAsync(id);
            if (projectMade == null)
            {
                return NotFound();
            }
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyName", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyName", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndName", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyName", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // POST: ProjectMades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectMadeId,ProjectMadeName,ProjectMadeDescription,BackEndTechnologyId,FrontEndTechnologyId,OtherTechnologyId,DatabaseTechnologyId")] ProjectMade projectMade)
        {
            if (id != projectMade.ProjectMadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectMade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectMadeExists(projectMade.ProjectMadeId))
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
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyName", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyName", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndName", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyName", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // GET: ProjectMades/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMade
                .Include(p => p.BackEndTechnology)
                .Include(p => p.DatabaseTechnology)
                .Include(p => p.FrontEndTechnology)
                .Include(p => p.OtherTechnology)
                .FirstOrDefaultAsync(m => m.ProjectMadeId == id);
            if (projectMade == null)
            {
                return NotFound();
            }

            return View(projectMade);
        }

        // POST: ProjectMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectMade = await _context.ProjectMade.FindAsync(id);
            _context.ProjectMade.Remove(projectMade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectMadeExists(int id)
        {
            return _context.ProjectMade.Any(e => e.ProjectMadeId == id);
        }
    }
}
