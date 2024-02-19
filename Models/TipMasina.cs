namespace MediiProgProiect.Models
{
    public class TipMasina
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }
        public MasinaC MasinaC { get; set; }
        public int TipID { get; set; }
        public Tip Tip { get; set; }
    }
}
