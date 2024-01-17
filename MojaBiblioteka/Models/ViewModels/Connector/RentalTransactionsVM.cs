using Microsoft.VisualBasic;
using MojaBiblioteka.Models.Entities.Book;
using MojaBiblioteka.Models.Entities.Connector;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Models.ViewModels.Connector
{
    public class RentalTransactionsVM : RentalTransaction
    {
        public RentalTransactionsVM() { }

        public RentalTransactionsVM(
            RentalTransaction rentalTransaction
        )
        {
            BookIsbn = rentalTransaction.BookIsbn;
            UserId = rentalTransaction.UserId;
            Book = rentalTransaction.Book;
            User = rentalTransaction.User;
            RentalDate = rentalTransaction.RentalDate;
            DueDate = rentalTransaction.DueDate;
            ProlongTermCounter = rentalTransaction.ProlongTermCounter;
            Status = rentalTransaction.Status;
        }

        public static string GetStatusText(int Status) {
            string text;
            switch (Status)
            {
                case (int) BookStatus.Ordered:
                    text = "zamówiono";
                    break;
                case (int) BookStatus.Cancelled:
                    text = "anulowano zamówienie";
                    break;
                case (int) BookStatus.ReadyToPickUp:
                    text = "gotowe do odebrania";
                    break;
                case (int) BookStatus.PickedUp:
                    text = "odebrano";
                    break;
                case (int) BookStatus.NotPickedUp:
                    text = "nie odebrano";
                    break;
                case (int) BookStatus.Returned:
                    text = "zwrócono";
                    break;
                case (int) BookStatus.NotReturned:
                    text = "nie zwrócono";
                    break;
                case (int) BookStatus.Closed:
                    text = "zamknięto";
                    break;
                default:
                    text = "niezdefiniowano";
                    break;
            }

            return text;
        }
    }
}
