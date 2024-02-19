using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Cumparari
{
    public class CreateModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public CreateModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
                var masiniLista = _context.MasinaC
         .Select(x => new
         {
             x.ID,
             MasinaDesc = x.Marca + " - " + x.Model + " " + x.Pret
         });
            ViewData["Membru"] = new SelectList(masiniLista, "Email", "Membru");
            ViewData["MasinaC"] = new SelectList(_context.Membru, "Marca", "");
            return Page();
        }

        [BindProperty]
        public Cumparare Cumparare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cumparare == null || Cumparare == null)
            {
                return Page();
            }

            _context.Cumparare.Add(Cumparare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
