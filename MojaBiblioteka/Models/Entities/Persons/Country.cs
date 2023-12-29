using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class Country
    {
        public int CountryId { get; set; }
        [Display(Name = "Kraj"), Required, StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
