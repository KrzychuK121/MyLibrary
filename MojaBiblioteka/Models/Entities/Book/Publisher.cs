using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Book
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        //[RegularExpression(@"\\b[A-Z][a-z]*\\b")]
        [Display(Name = "Wydawnictwo"), Required, StringLength(55, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
