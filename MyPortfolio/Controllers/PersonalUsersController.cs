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
    public class PersonalUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalUser.ToListAsync());
        }

        // GET: PersonalUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalUser = await _context.PersonalUser
                .FirstOrDefaultAsync(m => m.PersonalUserId == id);
            if (personalUser == null)
            {
                return NotFound();
            }

            return View(personalUser);
        }

        // GET: PersonalUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalUserId,PersonalFullName,Birthplace,Email,GitLink")] PersonalUser personalUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalUser);
        }

        // GET: PersonalUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalUser = await _context.PersonalUser.FindAsync(id);
            if (personalUser == null)
            {
                return NotFound();
            }
            return View(personalUser);
        }

        // POST: PersonalUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalUserId,PersonalFullName,Birthplace,Email,GitLink")] PersonalUser personalUser)
        {
            if (id != personalUser.PersonalUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalUserExists(personalUser.PersonalUserId))
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
            return View(personalUser);
        }

        // GET: PersonalUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalUser = await _context.PersonalUser
                .FirstOrDefaultAsync(m => m.PersonalUserId == id);
            if (personalUser == null)
            {
                return NotFound();
            }

            return View(personalUser);
        }

        // POST: PersonalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalUser = await _context.PersonalUser.FindAsync(id);
            _context.PersonalUser.Remove(personalUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalUserExists(int id)
        {
            return _context.PersonalUser.Any(e => e.PersonalUserId == id);
        }
    }
}
