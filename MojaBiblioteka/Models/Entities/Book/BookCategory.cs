namespace MojaBiblioteka.Models.Entities.Book
{
    public class BookCategory
    {
        public string BookIsbn { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Book Book { get; set; }
    }
}
