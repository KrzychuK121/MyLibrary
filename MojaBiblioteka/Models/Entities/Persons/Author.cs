using MojaBiblioteka.Models.Entities.Book;
using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "Imię"), Required]
        public Name Name { get; set; }
        [Display(Name = "Nazwisko"), Required]
        public LastName Surname { get; set; }
        [Display(Name = "Data urodzenia"), DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Książki")]
        public ICollection<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}
