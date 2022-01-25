using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Areas.Admin.Models;
using MyPortfolio.Data;

namespace MyPortfolio.Areas.Admin.Views
{
    [Area("Admin")]
    public class ProjectMadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectMadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProjectMades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectMades.Include(p => p.BackEndTechnology).Include(p => p.DatabaseTechnology).Include(p => p.FrontEndTechnology).Include(p => p.OtherTechnology);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProjectMades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMades
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

        // GET: Admin/ProjectMades/Create
        public IActionResult Create()
        {
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId");
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyId");
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndTechnologyId");
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyId");
            return View();
        }

        // POST: Admin/ProjectMades/Create
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
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyId", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndTechnologyId", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyId", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // GET: Admin/ProjectMades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMades.FindAsync(id);
            if (projectMade == null)
            {
                return NotFound();
            }
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyId", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndTechnologyId", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyId", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // POST: Admin/ProjectMades/Edit/5
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
            ViewData["BackEndTechnologyId"] = new SelectList(_context.BackEndTechnology, "BackEndTechnologyId", "BackEndTechnologyId", projectMade.BackEndTechnologyId);
            ViewData["DatabaseTechnologyId"] = new SelectList(_context.DatabaseTechnology, "DatabaseTechnologyId", "DatabaseTechnologyId", projectMade.DatabaseTechnologyId);
            ViewData["FrontEndTechnologyId"] = new SelectList(_context.FrontEndTechnology, "FrontEndTechnologyId", "FrontEndTechnologyId", projectMade.FrontEndTechnologyId);
            ViewData["OtherTechnologyId"] = new SelectList(_context.OtherTechnology, "OtherTechnologyId", "OtherTechnologyId", projectMade.OtherTechnologyId);
            return View(projectMade);
        }

        // GET: Admin/ProjectMades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectMade = await _context.ProjectMades
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

        // POST: Admin/ProjectMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectMade = await _context.ProjectMades.FindAsync(id);
            _context.ProjectMades.Remove(projectMade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectMadeExists(int id)
        {
            return _context.ProjectMades.Any(e => e.ProjectMadeId == id);
        }
    }
}
