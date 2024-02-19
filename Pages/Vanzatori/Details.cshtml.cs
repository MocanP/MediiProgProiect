using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Vanzatori
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public DetailsModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

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
    }
}
