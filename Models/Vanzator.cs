using System.ComponentModel.DataAnnotations;

namespace MediiProgProiect.Models
{
    public class Vanzator
    {
        public int ID { get; set; }
        [Display(Name = "Nume Vanzator")]
        public string NumeVanzator { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        public ICollection<MasinaC>? MasiniC { get; set; }
    }

}
