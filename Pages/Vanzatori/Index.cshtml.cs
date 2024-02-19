using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;
using MediiProgProiect.Models.ViewModels;

namespace MediiProgProiect.Pages.Vanzatori
{
    public class IndexModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public IndexModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IList<Vanzator> Vanzator { get;set; } = default!;

        public IndexVanzator DateVanzator { get; set; }
        public int VanzatorID { get; set; }
        public int MasinaID { get; set; }
        public async Task OnGetAsync(int? id, int? masinaID)
        {
            DateVanzator = new IndexVanzator();
            DateVanzator.Vanzatori = await _context.Vanzator
            .Include(i => i.MasiniC)
            .OrderBy(i => i.NumeVanzator)
            .ToListAsync();
            if (id != null)
            {
                VanzatorID = id.Value;
                Vanzator vanzator = DateVanzator.Vanzatori
                .Where(i => i.ID == id.Value).Single();
                DateVanzator.Masini = vanzator.MasiniC;
            }
        }
    }
}
