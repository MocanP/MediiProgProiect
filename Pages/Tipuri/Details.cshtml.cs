using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Tipuri
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public DetailsModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

      public Tip Tip { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip.FirstOrDefaultAsync(m => m.ID == id);
            if (tip == null)
            {
                return NotFound();
            }
            else 
            {
                Tip = tip;
            }
            return Page();
        }
    }
}
