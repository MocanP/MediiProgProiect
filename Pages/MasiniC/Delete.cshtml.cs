using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace MediiProgProiect.Pages.MasiniC
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public DeleteModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MasinaC == null)
            {
                return NotFound();
            }
            var masinac = await _context.MasinaC.FindAsync(id);

            if (masinac != null)
            {
                MasinaC = masinac;
                _context.MasinaC.Remove(MasinaC);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
