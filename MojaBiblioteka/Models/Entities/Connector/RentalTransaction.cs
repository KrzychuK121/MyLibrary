using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Persons;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojaBiblioteka.Models.Entities.Connector
{
    public class RentalTransaction
    {
        public int RentalTransactionId { get; set; }
        public string BookIsbn { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Książka")]
        public Book.Book Book { get; set; }
        [Display(Name = "Użytkownik")]
        public User User { get; set; }
        [Required]
        [Display(Name = "Data wypożyczenia"), DataType(DataType.Date)]
        public DateTime RentalDate { get; set; } = DateTime.Now.Date;
        [Required]
        [Display(Name = "Data zwrotu"), DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Now.Date.AddMonths(3);
        [Required, Range(0, 3)]
        [Display(Name = "Możliwa ilość przedłużeń")]
        [Description("How many times can User prolong the term of the book return. Going from 3 to 0")]
        public int ProlongTermCounter { get; set; } = 3;
        [Required]
        public int Status { get; set; } = (int) BookStatus.Ordered; // BookStatus here

    }

    public enum BookStatus
    {
        Ordered,
        Cancelled,
        ReadyToPickUp,
        PickedUp,
        NotPickedUp,
        Returned,
        NotReturned,
        Closed // Thread closed, archived
    }
}
