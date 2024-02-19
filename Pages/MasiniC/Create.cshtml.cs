using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiProgProiect.Data;
using MediiProgProiect.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace MediiProgProiect.Pages.MasiniC
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : TipMasinaModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public CreateModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VanzatorID"] = new SelectList(_context.Set<Vanzator>(), "ID","NumeVanzator");
            return Page();
        }

        [BindProperty]
        public MasinaC MasinaC { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MasinaC == null || MasinaC == null)
            {
                return Page();
            }

            _context.MasinaC.Add(MasinaC);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
