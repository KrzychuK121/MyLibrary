using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data
{
    public class SeedAuthorData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MyLibraryContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<MyLibraryContext>
                    >()
                ))
            {
                if (context.Authors.Any())
                    return; //Seeded

                var Names = new Name[]
                {
                    new Name { FirstName = "maciek" },
                    new Name { FirstName = "ania" },
                    new Name { FirstName = "bartek" },
                    new Name { FirstName = "marta" }
                };

                Console.WriteLine("Dlugosc Names: " + Names.Length);

                //context.Name.AddRange(Names);
                foreach(Name name in Names)
                {
                    context.Names.Add(name);
                }

                context.SaveChanges();

                var LastNames = new LastName[]
                {
                    new LastName { Surname = "podlaski" },
                    new LastName { Surname = "kubicka" },
                    new LastName { Surname = "kulesza" },
                    new LastName { Surname = "skowronek" }
                };

                Console.WriteLine("Dlugosc LastNames: " + LastNames.Length);

                //context.LastName.AddRange(LastNames);
                foreach (LastName lastName in LastNames)
                {
                    context.LastNames.Add(lastName);
                }

                context.SaveChanges();

                context.Authors.AddRange(
                    new Author
                    {
                        DateOfBirth = DateTime.Now,
                        FirstName  = Names.Single(n => n.FirstName.Equals("maciek")),
                        Surname = LastNames.Single(l => l.Surname.Equals("podlaski")),
                    },
                    new Author
                    {
                        DateOfBirth = DateTime.Now,
                        FirstName = Names.Single(n => n.FirstName.Equals("ania")),
                        Surname = LastNames.Single(l => l.Surname.Equals("kubicka"))
                    },
                    new Author
                    {
                        DateOfBirth = DateTime.Now,
                        FirstName = Names.Single(n => n.FirstName.Equals("bartek")),
                        Surname = LastNames.Single(l => l.Surname.Equals("kulesza"))
                    },
                    new Author
                    {
                        DateOfBirth = DateTime.Now,
                        FirstName = Names.Single(n => n.FirstName.Equals("marta")),
                        Surname = LastNames.Single(l => l.Surname.Equals("skowronek"))
                    }
                );

                context.SaveChanges();
            }

        }

    }
}
