using System.ComponentModel.DataAnnotations;

namespace MediiProgProiect.Models
{
    public class Tip
    {
        public int ID { get; set; }
        [Display(Name = "Tipul Masinii")]
        public string NumeTip { get; set; }
        public ICollection<TipMasina>? TipMasini { get; set; }
    }
}
