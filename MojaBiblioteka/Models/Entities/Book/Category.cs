using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Book
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Nazwa"), Required, StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [Display(Name = "Książki")]
        public ICollection<BookCategory>? BookCategory { get; set; }
    }
}
