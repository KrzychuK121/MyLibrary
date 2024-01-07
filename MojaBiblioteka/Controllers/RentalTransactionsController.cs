using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Data;
using MojaBiblioteka.Models.Entities.Connector;

namespace MojaBiblioteka.Controllers
{
    public class RentalTransactionsController : Controller
    {
        private readonly MyLibraryContext _context;

        public RentalTransactionsController(MyLibraryContext context)
        {
            _context = context;
        }

        // GET: RentalTransactions
        public async Task<IActionResult> Index()
        {
            var rentalTransactionList = await _context.RentalTransactionList
                .Include(r => r.Book)
                    .ThenInclude(b => b.Publisher)
                .Include(r => r.Book)
                    .ThenInclude(b => b.BookCategory)
                        .ThenInclude(bc => bc.Category)
                .Include(r => r.Book)
                    .ThenInclude(b => b.BookAuthor)
                        .ThenInclude(ba => ba.Author)
                            .ThenInclude(a => a.FirstName)
                .Include(r => r.Book)
                    .ThenInclude(b => b.BookAuthor)
                        .ThenInclude(ba => ba.Author)
                            .ThenInclude(a => a.Surname)
                .Include(r => r.User)
                    .ThenInclude(u => u.FirstName)
                .Include(r => r.User)
                    .ThenInclude(u => u.Surname)
                .AsNoTracking()
                .ToListAsync();

            return View(rentalTransactionList);
        }

        // GET: RentalTransactions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await _context.RentalTransactionList
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.BookIsbn == id);
            if (rentalTransaction == null)
            {
                return NotFound();
            }

            return View(rentalTransaction);
        }

        // GET: RentalTransactions/Create
        public IActionResult Create()
        {
            ViewData["BookIsbn"] = new SelectList(_context.Books, "Isbn", "Isbn");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RentalTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookIsbn,UserId,RentalDate,DueDate,ProlongTermCounter,Status")] RentalTransaction rentalTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookIsbn"] = new SelectList(_context.Books, "Isbn", "Isbn", rentalTransaction.BookIsbn);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentalTransaction.UserId);
            return View(rentalTransaction);
        }

        // GET: RentalTransactions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await _context.RentalTransactionList.FindAsync(id);
            if (rentalTransaction == null)
            {
                return NotFound();
            }
            ViewData["BookIsbn"] = new SelectList(_context.Books, "Isbn", "Isbn", rentalTransaction.BookIsbn);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentalTransaction.UserId);
            return View(rentalTransaction);
        }

        // POST: RentalTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookIsbn,UserId,RentalDate,DueDate,ProlongTermCounter,Status")] RentalTransaction rentalTransaction)
        {
            if (id != rentalTransaction.BookIsbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalTransactionExists(rentalTransaction.BookIsbn))
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
            ViewData["BookIsbn"] = new SelectList(_context.Books, "Isbn", "Isbn", rentalTransaction.BookIsbn);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentalTransaction.UserId);
            return View(rentalTransaction);
        }

        // GET: RentalTransactions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await _context.RentalTransactionList
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.BookIsbn == id);
            if (rentalTransaction == null)
            {
                return NotFound();
            }

            return View(rentalTransaction);
        }

        // POST: RentalTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.RentalTransactionList == null)
            {
                return Problem("Entity set 'MyLibraryContext.RentalTransactionList'  is null.");
            }
            var rentalTransaction = await _context.RentalTransactionList.FindAsync(id);
            if (rentalTransaction != null)
            {
                _context.RentalTransactionList.Remove(rentalTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalTransactionExists(string id)
        {
          return (_context.RentalTransactionList?.Any(e => e.BookIsbn == id)).GetValueOrDefault();
        }
    }
}
