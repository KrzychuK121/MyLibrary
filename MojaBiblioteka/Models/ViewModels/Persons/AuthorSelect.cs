using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Models.ViewModels.Persons
{
    public class AuthorSelect
    {
        public int AuthorId { get; set; }
        public Name FirstName { get; set; }
        public LastName Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description 
        {
            get
            {
                string dateStr = DateOfBirth.ToString();
                string dateToDisplay = DateOfBirth is null ? "Brak" : dateStr.Substring(0, dateStr.IndexOf(" "));

                return Capitalize(FirstName.FirstName) + " " + 
                    Capitalize(Surname.Surname) + (DateOfBirth != null ? " " : "") +
                    ", ur: " + dateToDisplay;
            }
        }

        private string Capitalize(string s)
        {
            return string.Concat(s[0].ToString().ToUpper(), s.AsSpan(1));
        }
    }
}
