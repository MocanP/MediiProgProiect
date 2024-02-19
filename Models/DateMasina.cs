namespace MediiProgProiect.Models
{
    public class DateMasina
    {
        public IEnumerable<MasinaC> Masini { get; set; }
        public IEnumerable<Tip> Tipuri { get; set; }
        public IEnumerable<TipMasina> TipMasini { get; set; }

    }
}
