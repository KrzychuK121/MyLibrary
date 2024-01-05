using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class User : IdentityUser
    {
        [Display(Name = "Imię"), Required]
        public Name FirstName { get; set; } = new Name { FirstName = string.Empty };
        [Required]
        public int? FirstNameNameId { get; set; }
        [Display(Name = "Nazwisko"), Required]
        public LastName Surname { get; set; } = new LastName { Surname = string.Empty };
        [Required]
        public int? SurnameLastNameId { get; set; }
    }
}
