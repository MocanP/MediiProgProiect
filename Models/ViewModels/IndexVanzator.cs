using System.Security.Policy;

namespace MediiProgProiect.Models.ViewModels
{
    public class IndexVanzator
    {

        public IEnumerable<Vanzator> Vanzatori { get; set; }
        public IEnumerable<MasinaC> Masini { get; set; }

    }
}
