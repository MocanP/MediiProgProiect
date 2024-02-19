using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace MediiProgProiect.Pages.MasiniC
{
    [Authorize(Roles = "Admin")]
    public class EditModel : TipMasinaModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public EditModel(MediiProgProiect.Data.MediiProgProiectContext context)
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

            var masinac =  await _context.MasinaC.FirstOrDefaultAsync(m => m.ID == id);
            if (masinac == null)
            {
                return NotFound();
            }
            MasinaC = masinac;
            ViewData["VanzatorID"] = new SelectList(_context.Set<Vanzator>(), "ID","NumeVanzator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MasinaC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasinaCExists(MasinaC.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasinaCExists(int id)
        {
          return (_context.MasinaC?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
