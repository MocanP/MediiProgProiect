﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Tipuri
{
    public class EditModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public EditModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tip Tip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip =  await _context.Tip.FirstOrDefaultAsync(m => m.ID == id);
            if (tip == null)
            {
                return NotFound();
            }
            Tip = tip;
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

            _context.Attach(Tip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipExists(Tip.ID))
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

        private bool TipExists(int id)
        {
          return (_context.Tip?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
