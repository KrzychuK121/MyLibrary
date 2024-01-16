using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Connector;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data.Seeds
{
    public class SeedDatabase
    {
        private readonly MyLibraryContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IPasswordHasher<User> passwordHasher;

        public SeedDatabase(IServiceProvider serviceProvider)
        {
            context = new MyLibraryContext
                (
                    serviceProvider.GetRequiredService
                    <
                        DbContextOptions<MyLibraryContext>
                    >()
                );

            roleManager = serviceProvider.GetRequiredService
                <
                    RoleManager<IdentityRole>
                >();

            passwordHasher = serviceProvider.GetRequiredService
                <
                    PasswordHasher<User>
                >();
        }

        public void SeedPublishers()
        {
            Console.WriteLine("\n------SeedPublishers()------");

            if (context.Publishers.Any())
            {
                Console.WriteLine("\nNo publishers created.\n");
                return;
            }

            var Publishers = new Publisher[]
                {
                    new Publisher { Name = "Wyd.Artystyczne GCE 2017" },
                    new Publisher { Name = "GREG" },
                    new Publisher { Name = "\"G&P\" ; [Warszawa] : Porozumienie Wydawców, 2003" }
                };

            foreach (Publisher publisher in Publishers)
            {
                Console.WriteLine($"\nCreating publisher { publisher.Name }\n");
                context.Add(publisher);
            }

            context.SaveChanges();
            Console.WriteLine("----------------------------\n");
        }

        public void SeedCategories()
        {
            Console.WriteLine("\n------SeedCategories()------");

            if(context.Categories.Any()) 
            {
                Console.WriteLine("\nNo categories created.\n");
                return;
            }

            var Categories = new Category[]
                {
                    new Category { Name = "historyczna" },
                    new Category { Name = "przygodowa" },
                    new Category { Name = "ludowa" }
                };

            foreach(var category in Categories)
            {
                Console.WriteLine($"\nCreating category { category.Name }\n");
                context.Add(category);
            }

            context.SaveChanges();
            Console.WriteLine("----------------------------\n");
        }

        public void SeedNames() 
        {
            Console.WriteLine("\n------SeedNames()------");
            if (context.Names.Any())
            {
                Console.WriteLine("\nNo names created.\n");
                return;
            }

            var Names = new Name[]
                {
                    new Name { FirstName = "henryk" },
                    new Name { FirstName = "adam" },
                    new Name { FirstName = "jan" },
                    new Name { FirstName = "admin" },
                    new Name { FirstName = "pracownik" },
                    new Name { FirstName = "klient" },
                    new Name { FirstName = "klient2" },
                    new Name { FirstName = "klient3" }
                };

            foreach(var name in Names)
            {
                Console.WriteLine($"\nCreating name { name.FirstName }\n");
                context.Add(name);
            }

            context.SaveChanges();
            Console.WriteLine("-----------------------\n");

        }

        public void SeedLastNames()
        {
            Console.WriteLine("\n------SeedLastNames()------");
            if (context.LastNames.Any())
            {
                Console.WriteLine("\nNo lastNames created.\n");
                return;
            }

            var LastNames = new LastName[]
                {
                    new LastName { Surname = "sienkiewicz" },
                    new LastName { Surname = "mickiewicz" },
                    new LastName { Surname = "brzechwa" },
                    new LastName { Surname = "szancer" },
                    new LastName { Surname = "admin" },
                    new LastName { Surname = "pracownik" },
                    new LastName { Surname = "klient" },
                    new LastName { Surname = "klient2" },
                    new LastName { Surname = "klient3" }
                };

            foreach (var lastName in LastNames)
            {
                Console.WriteLine($"\nCreating lastName { lastName.Surname }\n");
                context.Add(lastName);
            }

            context.SaveChanges();
            Console.WriteLine("---------------------------\n");

        }

        public void SeedAuthors()
        {
            Console.WriteLine("\n------SeedAuthors()------");
            if (context.Authors.Any())
            {
                Console.WriteLine("\nNo authors created.\n");
                return;
            }

            if (!context.Names.Any())
            {
                Console.WriteLine("\nNo names. Using SeedNames().\n");
                SeedNames();
            }

            if (!context.LastNames.Any())
            {
                Console.WriteLine("\nNo lastNames. Using SeedLastNames().\n");
                SeedLastNames();
            }

            var Authors = new Author[]
                {
                    new Author
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("adam")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("mickiewicz")),
                        DateOfBirth = new DateTime(1798, 12, 24)
                    },
                    new Author
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("henryk")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("sienkiewicz")),
                        DateOfBirth = new DateTime(1846, 5, 5)
                    },
                    new Author
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("jan")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("brzechwa")),
                        DateOfBirth = new DateTime(1898, 8, 15)
                    },
                    new Author
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("jan")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("szancer"))
                    }
                    
                };

            foreach (var author in Authors)
            {
                Console.WriteLine($"\nCreating author { author.FirstName.FirstName } { author.Surname.Surname }\n");
                context.Add(author);
            }

            context.SaveChanges();
            Console.WriteLine("-------------------------\n");
        }

        public void SeedBooks()
        {
            Console.WriteLine("\n------SeedBooks()------");
            if (context.Books.Any())
            {
                Console.WriteLine("\nNo books created.\n");
                return;
            }

            if (!context.Publishers.Any())
            {
                Console.WriteLine("\nNo publishers. Using SeedPublishers().\n");
                SeedPublishers();
            }

            var Books = new Book[]
                {
                    new Book
                    {
                        Isbn = "97883732718381234",
                        Title = "Dziady",
                        Publisher = context.Publishers.Single(p => p.Name.Equals("GREG")),
                        ReleaseDate = new DateTime(2002, 1, 1),
                        Amount = 8
                    },
                    new Book
                    {
                        Isbn = "97883926478501234",
                        Title = "Potop",
                        Publisher = context.Publishers.Single(p => p.Name.Equals("Wyd. Artystyczne GCE 2017")),
                        ReleaseDate = new DateTime(2006, 1, 1),
                        Amount = 3
                    },
                    new Book
                    {
                        Isbn = "83759682765692392",
                        Title = "Pan Kleks",
                        Publisher = context.Publishers.Single(p => p.Name.Equals("\"G&P\" ; [Warszawa] : Porozumienie Wydawców, 2003")),
                        ReleaseDate = new DateTime(2003, 1, 1),
                        Amount = 1
                    }

                };

            foreach (var book in Books)
            {
                Console.WriteLine($"\nCreating book { book.Isbn }: { book.Title }\n");
                context.Add(book);
            }

            context.SaveChanges();

            Console.WriteLine("-----------------------\n");
        }

        public void SeedBooksCategories()
        {
            Console.WriteLine("\n------SeedBooksCategories()------");
            if (context.BooksCategories.Any())
            {
                Console.WriteLine("\nNo booksCategories created.\n");
                return;
            }

            if (!context.Books.Any())
            {
                Console.WriteLine("\nNo books. Using SeedBooks().\n");
                SeedBooks();
            }

            if (!context.Categories.Any()) 
            {
                Console.WriteLine("\nNo categories. Using SeedCategories().\n");
                SeedCategories();
            }

            var BooksCategories = new BookCategory[]
                {
                    new BookCategory
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883732718381234")),
                        Category = context.Categories.Single(c => c.Name.Equals("historyczna"))
                    },
                    new BookCategory
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883926478501234")),
                        Category = context.Categories.Single(c => c.Name.Equals("historyczna"))
                    },
                    new BookCategory
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883926478501234")),
                        Category = context.Categories.Single(c => c.Name.Equals("przygodowa"))
                    },
                    new BookCategory
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883732718381234")),
                        Category = context.Categories.Single(c => c.Name.Equals("ludowa"))
                    }

                };

            foreach (var bookCategory in BooksCategories)
            {
                Console.WriteLine($"\nCreating booksCategories { bookCategory.Book.Title }: { bookCategory.Category.Name }\n");
                context.Add(bookCategory);
            }

            context.SaveChanges();

            Console.WriteLine("---------------------------------\n");
        }

        public void SeedBooksAuthors()
        {
            Console.WriteLine("\n------SeedBooksAuthors()------");
            if (context.BooksAuthors.Any())
            {
                Console.WriteLine("\nNo booksAuthors created.\n");
                return;
            }

            if (!context.Books.Any())
            {
                Console.WriteLine("\nNo books. Using SeedBooks().\n");
                SeedBooks();
            }

            if (!context.Authors.Any())
            {
                Console.WriteLine("\nNo authors. Using SeedAuthors().\n");
                SeedAuthors();
            }

            var BooksAuthors = new BookAuthor[]
                {
                    new BookAuthor
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883732718381234")),
                        Author = context.Authors.Single
                            (
                                a => a.FirstName.FirstName.Equals("adam") &&
                                a.Surname.Surname.Equals("mickiewicz")
                            )
                    },
                    new BookAuthor
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("97883926478501234")),
                        Author = context.Authors.Single
                            (
                                a => a.FirstName.FirstName.Equals("henryk") &&
                                a.Surname.Surname.Equals("sienkiewicz")
                            )
                    },
                    new BookAuthor
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("83759682765692392")),
                        Author = context.Authors.Single
                            (
                                a => a.FirstName.FirstName.Equals("jan") &&
                                a.Surname.Surname.Equals("brzechwa")
                            )
                    },
                    new BookAuthor
                    {
                        Book = context.Books.Single(b => b.Isbn.Equals("83759682765692392")),
                        Author = context.Authors.Single
                            (
                                a => a.FirstName.FirstName.Equals("jan") &&
                                a.Surname.Surname.Equals("szancer")
                            )
                    }

                };

            foreach (var bookAuthor in BooksAuthors)
            {
                Console.WriteLine($"\nCreating booksAuthors { bookAuthor.Book.Title }: " +
                    $"{ bookAuthor.Author.FirstName.FirstName } { bookAuthor.Author.Surname.Surname }\n");
                context.Add(bookAuthor);
            }

            context.SaveChanges();

            Console.WriteLine("------------------------------\n");
        }

        public void SeedRoles()
        {
            bool ifRolesCreated = false;

            string[] roles = { "Admin", "Employee", "Client" };

            Console.WriteLine("\n------SeedRoles()------");

            foreach (var role in roles)
            {

                if (roleManager.RoleExistsAsync(role).Result)
                    continue;

                ifRolesCreated = true;
                Console.WriteLine($"\nCreating role { role }\n");

                var identityRole = new IdentityRole(role);
                var result = roleManager.CreateAsync(identityRole).Result;
                if (!result.Succeeded)
                    throw new ApplicationException($"Error while creating the { role } role");

            }
            if (!ifRolesCreated)
                Console.WriteLine("\nNo roles created.\n");
            Console.WriteLine("-----------------------\n");
        }

        public void SeedUsers()
        {
            Console.WriteLine("\n------SeedUsers()------");
            if (context.Users.Any())
            {
                Console.WriteLine("\nNo users created.\n");
                return;
            }

            if (!context.Roles.Any())
            {
                Console.WriteLine("\nNo roles. Using SeedRoles().\n");
                SeedRoles();
            }

            var Emails = new List<string>()
            {
                "administrator@test.com",
                "pracownik@test.com",
                "klient@test.com",
                "klient2@test.com",
                "klient3@test.com"
            };

            var Passwords = new List<string>()
            {
                "Adm1n1str@tor",
                "Pr@cown1k",
                "Kl1&nt",
                "Kl1&nt",
                "Kl1&nt"
            };

            var Users = new User[]
                {
                    new User
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("admin")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("admin"))
                    },
                    new User
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("pracownik")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("pracownik"))
                    },
                    new User
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("klient")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("klient"))
                    },
                    new User
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("klient2")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("klient2"))
                    },
                    new User
                    {
                        FirstName = context.Names.Single(n => n.FirstName.Equals("klient3")),
                        Surname = context.LastNames.Single(ln => ln.Surname.Equals("klient3"))
                    },

                };

            for (var i = 0; i < Users.Length; i++)
            {
                Console.WriteLine($"\nCreating user { Users[i].FirstName.FirstName } { Users[i].Surname.Surname }\n");

                Users[i].UserName = Emails[i];
                Users[i].Email = Emails[i];
                Users[i].NormalizedUserName = Emails[i].ToUpper();
                Users[i].NormalizedEmail = Emails[i].ToUpper();
                Users[i].EmailConfirmed = true;
                passwordHasher.HashPassword(Users[i], Passwords[i]);

                context.Add(Users[i]);
            }

            context.SaveChanges();

            Console.WriteLine("-----------------------\n");
        }

        public void SeedUsersRoles()
        {
            Console.WriteLine("\n------SeedUsersRoles()------");
            if (context.UserRoles.Any())
            {
                Console.WriteLine("\nNo usersRoles created.\n");
                return;
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("\nNo users. Using SeedUsers().\n");
                SeedUsers();
            }

            if (!context.Roles.Any())
            {
                Console.WriteLine("\nNo roles. Using SeedRoles().\n");
                SeedRoles();
            }

            var UsersRoles = new IdentityUserRole<string>[]
                {
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(u => u.UserName.Equals("administrator@test.com")).Id,
                        RoleId = context.Roles.Single(r => r.Name.Equals("Admin")).Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(u => u.UserName.Equals("pracownik@test.com")).Id,
                        RoleId = context.Roles.Single(r => r.Name.Equals("Employee")).Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(u => u.UserName.Equals("klient@test.com")).Id,
                        RoleId = context.Roles.Single(r => r.Name.Equals("Client")).Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(u => u.UserName.Equals("klient2@test.com")).Id,
                        RoleId = context.Roles.Single(r => r.Name.Equals("Client")).Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(u => u.UserName.Equals("klient3@test.com")).Id,
                        RoleId = context.Roles.Single(r => r.Name.Equals("Client")).Id
                    },

                };

            foreach(var userRole in UsersRoles)
            {
                Console.WriteLine($"\nCreating userRole { userRole.UserId } : { userRole.RoleId }\n");
                context.Add(userRole);
            }

            context.SaveChanges();

            Console.WriteLine("----------------------------\n");
        }

        public void SeedRentalTransactions()
        {
            Console.WriteLine("\n------SeedRentalTransactions()------");
            if (context.RentalTransactionList.Any())
            {
                Console.WriteLine("\nNo rentalTransactions created.\n");
                return;
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("\nNo users. Using SeedUsers().\n");
                SeedUsers();
            }

            if (!context.Books.Any())
            {
                Console.WriteLine("\nNo books. Using SeedRoles().\n");
                SeedBooks();
            }

            var RentalTransactions = new RentalTransaction[]
                {
                    new RentalTransaction
                    {
                        User = context.Users.Single(u => u.UserName.Equals("klient@test.com")),
                        Book = context.Books.Single(b => b.Isbn.Equals("97883732718381234"))
                    },
                    new RentalTransaction
                    {
                        User = context.Users.Single(u => u.UserName.Equals("klient2@test.com")),
                        Book = context.Books.Single(b => b.Isbn.Equals("97883926478501234"))
                    },
                    new RentalTransaction
                    {
                        User = context.Users.Single(u => u.UserName.Equals("klient3@test.com")),
                        Book = context.Books.Single(b => b.Isbn.Equals("83759682765692392"))
                    },

                };

            foreach (var rentalTransaction in RentalTransactions)
            {
                Console.WriteLine($"\nCreating rentalTransaction { rentalTransaction.Book.Title } : { rentalTransaction.User.UserName }\n");
                context.Add(rentalTransaction);
            }

            context.SaveChanges();

            Console.WriteLine("------------------------------------\n");
        }

        public void Initialize()
        {
            SeedPublishers();
            SeedCategories();
            SeedNames();
            SeedLastNames();
            SeedAuthors();
            SeedBooks();
            SeedBooksCategories();
            SeedBooksAuthors();
            SeedRoles();
            SeedUsers();
            SeedUsersRoles();
            SeedRentalTransactions();
        }
    }
}
