using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using MojaBiblioteka.Data;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Connector;
using MojaBiblioteka.Models.Entities.Persons;
using MojaBiblioteka.Models.ViewModels.Connector;
using MojaBiblioteka.Models.ViewModels.Messages;

namespace MojaBiblioteka.Controllers
{
    public class RentalTransactionsController : Controller
    {
        private readonly MyLibraryContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IQueryable<RentalTransaction> indexRentTransList;
        private readonly IQueryable<RentalTransaction> detailsRentTransList;

        public RentalTransactionsController(
            MyLibraryContext context,
            UserManager<User> userManager
        )
        {
            _context = context;
            _userManager = userManager;
            indexRentTransList = _context.RentalTransactionList
                .Include(rt => rt.Book)
                    .ThenInclude(b => b.Publisher);

            detailsRentTransList = _context.RentalTransactionList
                .Include(rt => rt.Book)
                    .ThenInclude(b => b.Publisher)
                .Include(rt => rt.Book)
                    .ThenInclude(b => b.BookCategory)
                        .ThenInclude(bc => bc.Category)
                .Include(rt => rt.Book)
                    .ThenInclude(b => b.BookAuthor)
                        .ThenInclude(ba => ba.Author)
                            .ThenInclude(a => a.FirstName)
                .Include(rt => rt.Book)
                    .ThenInclude(b => b.BookAuthor)
                        .ThenInclude(ba => ba.Author)
                            .ThenInclude(a => a.Surname);
        }

        // GET: RentalTransactions
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Index()
        {
            var rentalTransactionList = await GetRentalTransactionsLINQ(indexRentTransList)
                .AsNoTracking()
                .OrderBy(rt => rt.UserId)
                .ThenBy(rt => rt.DueDate)
                .ToListAsync();

            return View(rentalTransactionList);
        }

        // GET: RentalTransactions/Index?userId
        [Authorize(Roles = "Admin, Employee, Client")]
        public async Task<IActionResult> IndexUser(string userId)
        {
            if (userId == null || string.IsNullOrWhiteSpace(userId))
                return NotFound();

            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var rentalTransactionLINQBase = GetRentalTransactionsLINQ(indexRentTransList)
                .AsNoTracking()
                .OrderBy(rt => rt.DueDate);

            var rentalTransactionLINQ = rentalTransactionLINQBase
                    .Where(rt => rt.UserId.Equals(userId));

            if (User.IsInRole("Client"))
            {
                if(userId != loggedUserId)
                    userId = loggedUserId;
                rentalTransactionLINQ = rentalTransactionLINQBase
                    .Where(
                        rt => rt.UserId.Equals(userId) &&
                        rt.Status != (int) BookStatus.Cancelled &&
                        rt.Status != (int) BookStatus.Returned &&
                        rt.Status != (int) BookStatus.Closed
                    );
            }

            var rentalTransactionList = await rentalTransactionLINQ
                .ToListAsync();

            return View(rentalTransactionList);
        }

        // GET: RentalTransactions/Details/5
        public async Task<IActionResult> Details(int id, string? userId)
        {
            ViewData[nameof(userId)] = userId;

            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await GetRentalTransactionsLINQ(detailsRentTransList)
                .FirstOrDefaultAsync(rt => rt.RentalTransactionId == id);
            if (rentalTransaction == null)
            {
                return NotFound();
            }

            return View(rentalTransaction);
        }

        // POST: RentalTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string bookIsbn)
        {
            if (bookIsbn == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookToRent = await _context.Books
                    .AsNoTracking()
                    .SingleOrDefaultAsync(b => b.Isbn == bookIsbn);

            if (bookToRent == null)
                return NotFound();
            if(bookToRent.Amount == 0)
            {
                TempData["message"] = "Wybrana książka jest niedostępna. Poczekaj aż ktoś zwróci egzemplarz do biblioteki.";
                TempData["type"] = Types.Error;
                return RedirectToAction("Index", "Books");
            }
            // It returns rental transaction connected with logged user who wants to borrow this book.
            // But only when this book is not cancelled, returned or closed (he still has it or will have soon)
            // It will prevent user from renting the same book secound time while he shouldn't.
            var rental = await _context.RentalTransactionList
                .SingleOrDefaultAsync(rt => 
                    rt.BookIsbn.Equals(bookIsbn) && 
                    rt.UserId.Equals(userId) &&
                    rt.Status != (int) BookStatus.Cancelled &&
                    rt.Status != (int) BookStatus.Returned &&
                    rt.Status != (int) BookStatus.Closed
                );

            if (rental != null)
            {
                TempData["message"] = "Już wypożyczyłeś tę książkę. Upewnij się, że zwróciłeś książkę, którą chcesz wypożyczyć. " +
                    "Jeśli uważasz, że to błąd, skontaktuj się z nami.";
                TempData["type"] = Types.Error;
                return RedirectToAction("Index", "Books");
            }

            var rentalTransaction = new RentalTransaction {
                BookIsbn = bookIsbn,
                Book = bookToRent,
                UserId = userId,
                User = await _userManager.GetUserAsync(User)
            };

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(rentalTransaction);

                bookToRent.Amount--;
                _context.Update(bookToRent);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexUser), new { userId = userId });
            }

            return RedirectToAction("Index", "Books");
        }

        // POST: RentalTransactions/Cancel/5/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(string id, string userId)
        {
            var rentalTransactionToUpdate = await _context.RentalTransactionList
                .FirstOrDefaultAsync(rt => rt.UserId.Equals(userId));

            if (rentalTransactionToUpdate == null)
                return NotFound();

            rentalTransactionToUpdate.Status = (int) BookStatus.Cancelled;

            try
            {
                _context.Update(rentalTransactionToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalTransactionExists(rentalTransactionToUpdate.RentalTransactionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(IndexUser), new {userId = userId});
        }

        // POST: RentalTransactions/ProlongTerm/5/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProlongTerm(int id)
        {
            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var rentalTransactionToUpdate = await _context.RentalTransactionList
                .FirstOrDefaultAsync(rt => rt.RentalTransactionId == id);

            if(rentalTransactionToUpdate.UserId != loggedUserId)
                return NotFound();

            if(rentalTransactionToUpdate.ProlongTermCounter == 0)
            {
                TempData["message"] = "Nie masz już możliwości przedłużenia terminu oddania.";
                TempData["type"] = Types.Error;
                return RedirectToAction(nameof(IndexUser), new { userId = loggedUserId });
            }

            rentalTransactionToUpdate.DueDate.AddMonths(1);
            rentalTransactionToUpdate.ProlongTermCounter--;

            try
            {
                _context.Update(rentalTransactionToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalTransactionExists(rentalTransactionToUpdate.RentalTransactionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(IndexUser), new { userId = loggedUserId});
        }

        // GET: RentalTransactions/Edit/5
        public async Task<IActionResult> Edit(int id, string? userId)
        {
            ViewData[nameof(userId)] = userId;

            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await GetRentalTransactionsLINQ(detailsRentTransList)
                .FirstOrDefaultAsync(rt => rt.RentalTransactionId == id);

            if (rentalTransaction == null)
            {
                return NotFound();
            }

            StatusDropdown(rentalTransaction.Status);
            return View(rentalTransaction);
        }

        // POST: RentalTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit
        (
            int id, 
            [Bind("RentalTransactionId,BookIsbn,UserId,RentalDate,DueDate,ProlongTermCounter,Status")] RentalTransaction rentalTransaction, 
            string? userIdPath
        )
        {
            Console.WriteLine("\n" + userIdPath ?? "null" + "\n");

            if (id != rentalTransaction.RentalTransactionId)
            {
                return NotFound();
            }

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalTransactionExists(rentalTransaction.RentalTransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //Console.WriteLine("\nViewData: " + (ViewData[nameof(userId)] == null ? "null" : ViewData[nameof(userId)]) + "\n");

                if (userIdPath == null)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(IndexUser), new { userId = userIdPath });
            }
            StatusDropdown(rentalTransaction.Status);
            return View(rentalTransaction);
        }

        // GET: RentalTransactions/Delete/5
        public async Task<IActionResult> Delete(int id, string? userId)
        {
            ViewData[nameof(userId)] = userId;

            if (id == null || _context.RentalTransactionList == null)
            {
                return NotFound();
            }

            var rentalTransaction = await GetRentalTransactionsLINQ(detailsRentTransList)
                .FirstOrDefaultAsync(rt => rt.RentalTransactionId == id);
            if (rentalTransaction == null)
            {
                return NotFound();
            }

            return View(rentalTransaction);
        }

        // POST: RentalTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string? userId)
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
            if (userId == null)
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(IndexUser), new { userId = userId });
        }

        private bool RentalTransactionExists(int id)
        {
          return (_context.RentalTransactionList?.Any(e => e.RentalTransactionId == id)).GetValueOrDefault();
        }

        private IQueryable<RentalTransaction> GetRentalTransactionsLINQ(IQueryable<RentalTransaction> initLINQ)
        {
            var rentalTransactionLINQ = initLINQ;

            if (User.IsInRole("Employee") || User.IsInRole("Admin"))
                rentalTransactionLINQ = rentalTransactionLINQ
                    .Include(rt => rt.User)
                        .ThenInclude(u => u.FirstName)
                    .Include(rt => rt.User)
                        .ThenInclude(u => u.Surname);

            return rentalTransactionLINQ;
        }

        private void StatusDropdown(object selected = null)
        {
            // var status;
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var bookStatusCount = Enum.GetNames(typeof(BookStatus)).Length;

            for (var i = 0; i < bookStatusCount; i++)
            {
                selectListItems.Add(new SelectListItem 
                    { 
                        Text = RentalTransactionsVM.GetStatusText(i), 
                        Value = i.ToString()
                    }
                );
            }

            ViewBag.Status = new SelectList(selectListItems, "Value", "Text", selected);
        }
    }
}
