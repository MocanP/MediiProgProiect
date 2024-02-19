using MediiProgProiect.Data;
using MediiProgProiect.Migrations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediiProgProiect.Models
{
    public class TipMasinaModel : PageModel
    {
        public List<TipuriAlese> TipuriAleseLista;
        public void PopuleazaTipurileAlese(MediiProgProiectContext context,
        MasinaC masinac)
        {
            var ToateTipurile = context.Tip;
            var TipuriMasini = new HashSet<int>(
            masinac.TipMasini.Select(c => c.TipID));
            TipuriAleseLista = new List<TipuriAlese>();
            foreach (var cat in ToateTipurile)
            {
                TipuriAleseLista.Add(new TipuriAlese
                {
                    TipID = cat.ID,
                    Nume = cat.NumeTip,
                    Ales = TipuriMasini.Contains(cat.ID)
                });
            }
        }
        public void ActualizareTip(MediiProgProiectContext context,
        string[] TipuriSelectate, MasinaC masinaActualizata)
        {
            if (TipuriSelectate == null)
            {
                masinaActualizata.TipMasini = new List<TipMasina>();
                return;
            }
            var TipuriSelectateH = new HashSet<string>(TipuriSelectate);
            var TipuriMasini = new HashSet<int>
            (masinaActualizata.TipMasini.Select(c => c.Tip.ID));
            foreach (var cat in context.Tip)
            {
                if (TipuriSelectateH.Contains(cat.ID.ToString()))
                {
                    if (!TipuriMasini.Contains(cat.ID))
                    {
                        masinaActualizata.TipMasini.Add(
                        new TipMasina
                        {
                            MasinaID = masinaActualizata.ID,
                            TipID = cat.ID
                        });
                    }
                }
                else
                {
                    if (TipuriMasini.Contains(cat.ID))
                    {
                        TipMasina courseToRemove
                        = masinaActualizata
                        .TipMasini
                        .SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
