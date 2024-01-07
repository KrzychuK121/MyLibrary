using MojaBiblioteka.Models.Entities.Connector;
using MojaBiblioteka.Models.Entities.Persons;
using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Book
{
    public class Book
    {
        [Key, StringLength(17, MinimumLength = 17), Display(Name = "ISBN")]
        public string Isbn { get; set; }
        [Display(Name = "Tytuł"), Required, StringLength(30)]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data wydania"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Kategorie")]
        public ICollection<BookCategory>? BookCategory { get; set; } = new List<BookCategory>();
        [Display(Name = "Autorzy")]
        public ICollection<BookAuthor>? BookAuthor { get; set; } = new List<BookAuthor>();
        [Display(Name = "Wydawnictwo"), Required]
        public Publisher Publisher { get; set; }
        [Display(Name = "Wydawnictwo"), Required]
        public int PublisherId { get; set; }
        [Display(Name = "Ilość"), Required, Range(0, int.MaxValue)]
        public int Amount { get; set; }
        public ICollection<RentalTransaction>? RentalTransactionList { get; set; }

    }
}
