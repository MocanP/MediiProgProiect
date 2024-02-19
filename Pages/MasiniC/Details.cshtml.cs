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
    public class DetailsModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public DetailsModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

      public MasinaC MasinaC { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MasinaC == null)
            {
                return NotFound();
            }

            var masinac = await _context.MasinaC.FirstOrDefaultAsync(m => m.ID == id);
            if (masinac == null)
            {
                return NotFound();
            }
            else 
            {
                MasinaC = masinac;
            }
            return Page();
        }
    }
}
