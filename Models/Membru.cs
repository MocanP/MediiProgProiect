using System.ComponentModel.DataAnnotations;

namespace MediiProgProiect.Models
{
    public class Membru
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Numele trebuie sa inceapa cu majuscula.")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenume trebuie sa inceapa cu majuscula.")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [StringLength(70)]
        public string? Adresa { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [Display(Name = "Numele Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Cumparare>? Cumparari { get; set; }
    }
}
