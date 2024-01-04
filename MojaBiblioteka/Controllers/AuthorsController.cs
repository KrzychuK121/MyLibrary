using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Data;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly MyLibraryContext _context;

        public AuthorsController(MyLibraryContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                View(await _context.Authors
                    .Include(a => a.FirstName)
                    .Include(a => a.Surname)
                    .ToListAsync()
                ) :
                Problem("Entity set 'MyLibraryContext.Author'  is null.");
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.FirstName)
                .Include(a => a.Surname)
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,Name,Surname,DateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                var Name = await _context.Names
                    .Where(n => n.FirstName == author.FirstName.FirstName)
                    .FirstOrDefaultAsync();

                var Surname = await _context.LastNames
                    .Where(l => l.Surname == author.Surname.Surname)
                    .FirstOrDefaultAsync();

                if(Name != null)
                    author.FirstName = Name;
                if(Surname != null)
                    author.Surname = Surname;

                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.FirstName)
                .Include(a => a.Surname)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("AuthorId,Name,Surname,DateOfBirth")] Author author)
        {
            if(id != author.AuthorId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var Name = await _context.Names
                        .Where(n => n.FirstName == author.FirstName.FirstName)
                        .FirstOrDefaultAsync();

                    var Surname = await _context.LastNames
                        .Where(l => l.Surname == author.Surname.Surname)
                        .FirstOrDefaultAsync();

                    if (Name != null)
                        author.FirstName = Name;
                    if (Surname != null)
                        author.Surname = Surname;

                    _context.Update(author);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }

            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.FirstName)
                .Include(a => a.Surname)
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'MyLibraryContext.Author'  is null.");
            }
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
