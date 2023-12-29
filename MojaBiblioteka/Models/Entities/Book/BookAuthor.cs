using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Models.Entities.Book
{
    public class BookAuthor
    {
        public string BookIsbn {  get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
