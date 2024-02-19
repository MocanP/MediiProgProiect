using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MediiProgProiect.Models
{
    public class Cumparare
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? MasinaID { get; set; }
        public MasinaC? MasinaC { get; set; }
    }
}
