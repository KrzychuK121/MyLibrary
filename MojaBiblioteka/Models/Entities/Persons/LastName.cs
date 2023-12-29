using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class LastName
    {
        public int LastNameId { get; set; }
        [Display(Name = "Nazwisko"), Required, StringLength(30, MinimumLength = 3)]
        public string Surname { get; set; }
        [Display(Name = "Autorzy")]
        public ICollection<Author>? Authors { get; set; }
    }
}
