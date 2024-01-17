using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Data;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Persons;
using MojaBiblioteka.Models.ViewModels.Book;
using MojaBiblioteka.Models.ViewModels.Persons;
using Newtonsoft.Json.Bson;

namespace MojaBiblioteka.Controllers
{
    [Authorize(Roles = "Admin, Employee, Client")]
    public class BooksController : Controller
    {
        private readonly MyLibraryContext _context;

        public BooksController(MyLibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var myLibraryContext = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategory)
                    .ThenInclude(c => c.Category)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.FirstName)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.Surname)
                .AsNoTracking()
                .ToListAsync();

            if (TempData["message"] != null)
                ViewData["message"] = TempData["message"];

            if (TempData["type"] != null)
                ViewData["type"] = TempData["type"];

            return View(myLibraryContext);
        }

        // GET: Books/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategory)
                    .ThenInclude(c => c.Category)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.FirstName)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.Surname)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Isbn == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult Create()
        {
            PublishersDropdown();
            AuthorsDropdown();
            CategoriesCheckboxes(new Book());
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Create(
            [Bind("Isbn,Title,ReleaseDate,PublisherId,Amount")] Book book,
            string[] selectedCategories,
            string[] AuthorsId
        )
        {
            if (!book.PublisherId.Equals(""))
            {
                book.Publisher = await _context.Publishers
                    .SingleOrDefaultAsync(p => p.PublisherId == book.PublisherId);
            }
            if (selectedCategories != null)
            {
                book.BookCategory = new List<BookCategory>();
                foreach (string categoryId in selectedCategories)
                {
                    var BookCategory = new BookCategory { BookIsbn = book.Isbn, CategoryId = int.Parse(categoryId) };
                    book.BookCategory.Add(BookCategory);
                }
            }
            if (AuthorsId != null)
            {
                book.BookAuthor = new List<BookAuthor>();
                foreach(string authorId in AuthorsId)
                {
                    if (authorId.Equals(""))
                        continue;
                    var BookAuthor = new BookAuthor { BookIsbn = book.Isbn, AuthorId = int.Parse(authorId) };
                    book.BookAuthor.Add(BookAuthor);
                }
            }
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine(book.Publisher == null ? "null" : book.Publisher.PublisherId + " " + book.Publisher.Name);
                Console.WriteLine(book.PublisherId);
                foreach (var error in ModelState.Values.SelectMany(modelState => modelState.Errors)) 
                {
                    
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            PublishersDropdown(book.PublisherId);
            CategoriesCheckboxes(book);

            IEnumerable<int> selectedAuthors = new List<int>();
            foreach(var authorId in AuthorsId)
            {
                selectedAuthors.Append(int.Parse(authorId));
            }

            AuthorsDropdown(selectedAuthors);
            
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var bookToUpdate = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategory)
                    .ThenInclude(c => c.Category)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.FirstName)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.Surname)
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Isbn.Equals(id));

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            PublishersDropdown(bookToUpdate.PublisherId);
            CategoriesCheckboxes(bookToUpdate);
            AuthorsDropdown(bookToUpdate.BookAuthor.Select(b => b.AuthorId).ToArray());

            return View(bookToUpdate);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(
            string? id,
            string[] selectedCategories,
            string[] AuthorsId
        )
        {
            if (id is null)
            {
                return NotFound();
            }

            var bookToUpdate = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategory)
                    .ThenInclude(c => c.Category)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.FirstName)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.Surname)
                .SingleOrDefaultAsync(b => b.Isbn.Equals(id));

            if (await TryUpdateModelAsync<Book>(
                    bookToUpdate,
                    "",
                    b => b.Isbn, b => b.Title, b => b.ReleaseDate, b => b.Publisher, b => b.Amount
                )
            )
            {
                UpdateBookCategory(selectedCategories, bookToUpdate);
                UpdateBookAuthor(AuthorsId, bookToUpdate);

                try
                {
                    await _context.SaveChangesAsync();
                    Console.WriteLine();
                    Console.WriteLine("Zapisalo sie");
                    Console.WriteLine();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError(
                        "", 
                        "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator."
                    );
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateBookCategory(selectedCategories, bookToUpdate);
            UpdateBookAuthor(AuthorsId, bookToUpdate);

            PublishersDropdown(bookToUpdate.PublisherId);
            CategoriesCheckboxes(bookToUpdate);

            IEnumerable<int> selectedAuthors = new List<int>();
            foreach (var authorId in AuthorsId)
            {
                selectedAuthors.Append(int.Parse(authorId));
            }

            AuthorsDropdown(selectedAuthors);
            return View(bookToUpdate);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategory)
                    .ThenInclude(c => c.Category)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.FirstName)
                .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                        .ThenInclude(a => a.Surname)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Isbn == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'MyLibraryContext.Book'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(string id)
        {
          return (_context.Books?.Any(e => e.Isbn == id)).GetValueOrDefault();
        }

        private void UpdateBookCategory(string[] selectedCategory, Book bookToUpdate)
        {
            if(selectedCategory == null)
            {
                bookToUpdate.BookCategory = new List<BookCategory>();
                return;
            }

            var selectedCategoryHS = new HashSet<string>(selectedCategory);
            var bookCategory = new HashSet<int>(
                    bookToUpdate.BookCategory.Select(bc => bc.CategoryId)
                );

            foreach(var categories in _context.Categories)
            {
                if (selectedCategoryHS.Contains(categories.CategoryId.ToString()))
                {
                    // Jeśli zaznaczona a nie była kategorią to dodaj
                    if (!bookCategory.Contains(categories.CategoryId))
                    {
                        bookToUpdate.BookCategory.Add(
                            new BookCategory
                            {
                                BookIsbn = bookToUpdate.Isbn,
                                CategoryId = categories.CategoryId
                            }
                        );
                    }
                }
                else
                {
                    // Jeśli nie zaznaczona kategoria a była kategorią to usuń
                    if (bookCategory.Contains(categories.CategoryId))
                    {
                        BookCategory bookCategoryToRemove = bookToUpdate.BookCategory.FirstOrDefault(
                                bc => bc.CategoryId == categories.CategoryId
                            );
                        _context.Remove(bookCategoryToRemove);
                    }
                }
            }
        }

        private void UpdateBookAuthor(string[] selectedAuthors, Book bookToUpdate)
        {
            if (selectedAuthors == null)
            {
                bookToUpdate.BookAuthor = new List<BookAuthor>();
                return;
            }

            var selectedAuthorsHS = new HashSet<string>(selectedAuthors);
            var bookAuthorsHS = new HashSet<int>(
                    bookToUpdate.BookAuthor.Select(ba => ba.AuthorId)
                );

            foreach(var authors in _context.Authors)
            {
                if (selectedAuthorsHS.Contains(authors.AuthorId.ToString()))
                {
                    // Jeśli zaznaczony a nie przypisany to przypisz
                    if (!bookAuthorsHS.Contains(authors.AuthorId))
                    {
                        bookToUpdate.BookAuthor.Add(
                            new BookAuthor
                            {
                                BookIsbn = bookToUpdate.Isbn,
                                AuthorId = authors.AuthorId
                            }
                        );
                    }
                }
                else
                {
                    // Jeśli nie zaznaczony a przypisany to usuń
                    if (bookAuthorsHS.Contains(authors.AuthorId))
                    {
                        BookAuthor bookAuthorToRemove = bookToUpdate.BookAuthor.FirstOrDefault(
                                ba => ba.AuthorId == authors.AuthorId
                            );
                        _context.Remove(bookAuthorToRemove);
                    }
                }
            }
        }

        private void PublishersDropdown(object selected = null)
        {
            var publishers = from p in _context.Publishers
                             orderby p.Name
                             select p;

            IEnumerable<MojaBiblioteka.Models.Entities.Book.Publisher> s = publishers
                .AsNoTracking();

            /*foreach(Publisher publisher in s)
            {
                Console.WriteLine(publisher.PublisherId + " : " + publisher.Name);
            }*/

            ViewBag.PublishersId = new SelectList(s, "PublisherId", "Name", selected);
        }

        private void AuthorsDropdown(IEnumerable<int> selected = null)
        {
            var authors = from a in _context.Authors
                          orderby a.FirstName
                          select new AuthorSelect
                          {
                              AuthorId = a.AuthorId,
                              FirstName = a.FirstName,
                              Surname = a.Surname,
                              DateOfBirth = a.DateOfBirth
                          };

            IEnumerable<AuthorSelect> authorsList = authors.AsNoTracking();

            ViewBag.AuthorsSelect = new MultiSelectList(authorsList, "AuthorId", "Description", selected);
        }

        private void CategoriesCheckboxes(Book book)
        {
            var booksCategories = new HashSet<int>(book.BookCategory.Select(c => c.CategoryId));
            var viewModel = new List<CategoryChecked>();

            foreach (var category in _context.Categories)
            {
                viewModel.Add(new CategoryChecked
                {
                    Category = new Category 
                    { 
                        CategoryId = category.CategoryId, 
                        Name = category.Name 
                    },
                    Checked = booksCategories.Contains(category.CategoryId)
                });
            }
            ViewBag.Categories = viewModel;
        }
    }
}
