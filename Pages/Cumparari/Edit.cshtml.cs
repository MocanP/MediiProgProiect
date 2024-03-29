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

namespace MediiProgProiect.Pages.Cumparari
{
    public class EditModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public EditModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cumparare Cumparare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }

            var cumparare =  await _context.Cumparare.FirstOrDefaultAsync(m => m.ID == id);
            if (cumparare == null)
            {
                return NotFound();
            }
            Cumparare = cumparare;
           ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "ID");
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

            _context.Attach(Cumparare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CumparareExists(Cumparare.ID))
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

        private bool CumparareExists(int id)
        {
          return (_context.Cumparare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
