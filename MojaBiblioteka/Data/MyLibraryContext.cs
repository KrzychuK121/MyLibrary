﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data
{
    public class MyLibraryContext : DbContext
    {
        public MyLibraryContext (DbContextOptions<MyLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<BookCategory> BookCategory { get; set; } = default!;
        public DbSet<BookAuthor> BookAuthor { get; set; } = default!;
        public DbSet<Name> Names { get; set; } = default!;
        public DbSet<LastName> LastName { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(c => new { c.BookIsbn, c.CategoryId });
            modelBuilder.Entity<BookAuthor>()
                .HasKey(b => new { b.BookIsbn, b.AuthorId });
        }
    }
}
