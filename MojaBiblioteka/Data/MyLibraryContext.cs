using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data
{
    public class MyLibraryContext : IdentityDbContext<User>
    {
        public MyLibraryContext (DbContextOptions<MyLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<BookCategory> BooksCategories { get; set; } = default!;
        public DbSet<BookAuthor> BooksAuthors { get; set; } = default!;
        public DbSet<Name> Names { get; set; } = default!;
        public DbSet<LastName> LastNames { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookCategory>()
                .HasKey(c => new { c.BookIsbn, c.CategoryId });
            modelBuilder.Entity<BookAuthor>()
                .HasKey(b => new { b.BookIsbn, b.AuthorId });
        }
    }
}
