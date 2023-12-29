
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<LastName> LastNames { get; set; }
        public DbSet<Street> Streets { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
    }
}
