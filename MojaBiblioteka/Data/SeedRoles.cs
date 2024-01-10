using Microsoft.AspNetCore.Identity;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Data
{
    public class SeedRoles
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            bool ifRolesCreated = false;

            string[] roles = { "Admin", "Employee", "Client" };

            Console.WriteLine();
            Console.WriteLine("------SeedRoles.Initialize()------");

            foreach(var role in roles)
            {
                
                if (roleManager.RoleExistsAsync(role).Result)
                    continue;

                ifRolesCreated = true;
                Console.WriteLine($"\nCreating role {role}\n");

                var identityRole = new IdentityRole(role);
                var result = roleManager.CreateAsync(identityRole).Result;
                if (!result.Succeeded)
                    throw new ApplicationException($"Error while creating the {role} role");

            }
            if (!ifRolesCreated)
                Console.WriteLine("\nNo roles created.\n");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
        }
    }
}
