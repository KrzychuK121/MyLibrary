using System.ComponentModel.DataAnnotations;

namespace MojaBiblioteka.Models.Entities.Persons
{
    public class Street
    {
        public int StreetId { get; set; }
        [Display(Name = "Ulica"), Required]
        public string Name { get; set; }
    }
}
