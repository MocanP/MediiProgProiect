using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace MediiProgProiect.Models
{
    public class MasinaC
    {
        public int ID { get; set; }

        [Display(Name = "Marca Masinii")]
        [StringLength(70, MinimumLength = 1)]
        public string Marca { get; set; }

        [StringLength(70, MinimumLength = 1)]
        public string Model { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Data Fabricarii")]
        [DataType(DataType.Date)]
        public DateTime DataFabricarii { get; set; }

        public int? VanzatorID { get; set; }
        public Vanzator? Vanzator { get; set; }
        public int? CumparareID { get; set; }
        public Cumparare? Cumparare { get; set; }
        public ICollection<TipMasina>? TipMasini { get; set; }
    }

}
