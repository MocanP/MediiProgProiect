using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Membri
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
            return Page();
        }

        [BindProperty]
        public Membru Membru { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Membru == null || Membru == null)
            {
                return Page();
            }

            _context.Membru.Add(Membru);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
