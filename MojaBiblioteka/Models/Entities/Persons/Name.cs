using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class Name
    {
        public int NameId { get; set; }
        [Display(Name = "Imię"), Required, StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Display(Name = "Autorzy")]
        public ICollection<Author>? Authors { get; set; }
    }
}
