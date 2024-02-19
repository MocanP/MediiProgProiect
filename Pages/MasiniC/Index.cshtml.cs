using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.MasiniC
{
    public class IndexModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public IndexModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IList<MasinaC> MasinaC { get;set; } = default!;
        public string SortareMarca { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.MasinaC != null)
            {
                MasinaC = await _context.MasinaC.Include(b => b.Vanzator).ToListAsync();
            }
        }
    }
}
