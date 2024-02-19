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

namespace MediiProgProiect.Pages.Vanzatori
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
      public Vanzator Vanzator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vanzator == null)
            {
                return NotFound();
            }

            var vanzator = await _context.Vanzator.FirstOrDefaultAsync(m => m.ID == id);

            if (vanzator == null)
            {
                return NotFound();
            }
            else 
            {
                Vanzator = vanzator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vanzator == null)
            {
                return NotFound();
            }
            var vanzator = await _context.Vanzator.FindAsync(id);

            if (vanzator != null)
            {
                Vanzator = vanzator;
                _context.Vanzator.Remove(Vanzator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
