﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MojaBiblioteka.Data;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    [DbContext(typeof(MyLibraryContext))]
    [Migration("20231119113427_NoTitleModel")]
    partial class NoTitleModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<string>("BooksIsbn")
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("AuthorsAuthorId", "BooksIsbn");

                    b.HasIndex("BooksIsbn");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<string>("BooksIsbn")
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.HasKey("BooksIsbn", "CategoriesCategoryId");

                    b.HasIndex("CategoriesCategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Book.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Isbn");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Book.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Book.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("NameId")
                        .HasColumnType("int");

                    b.Property<int>("SurnameLastNameId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId");

                    b.HasIndex("NameId");

                    b.HasIndex("SurnameLastNameId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.LastName", b =>
                {
                    b.Property<int>("LastNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LastNameId"), 1L, 1);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("LastNameId");

                    b.ToTable("LastName");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.Name", b =>
                {
                    b.Property<int>("NameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NameId"), 1L, 1);

                    b.Property<string>("Fistname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("NameId");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("MojaBiblioteka.Models.Entities.Persons.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MojaBiblioteka.Models.Entities.Book.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("MojaBiblioteka.Models.Entities.Book.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MojaBiblioteka.Models.Entities.Book.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Book.Book", b =>
                {
                    b.HasOne("MojaBiblioteka.Models.Entities.Book.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.Author", b =>
                {
                    b.HasOne("MojaBiblioteka.Models.Entities.Persons.Name", "Name")
                        .WithMany("Authors")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MojaBiblioteka.Models.Entities.Persons.LastName", "Surname")
                        .WithMany("Authors")
                        .HasForeignKey("SurnameLastNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Name");

                    b.Navigation("Surname");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Book.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.LastName", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("MojaBiblioteka.Models.Entities.Persons.Name", b =>
                {
                    b.Navigation("Authors");
                });
#pragma warning restore 612, 618
        }
    }
}
