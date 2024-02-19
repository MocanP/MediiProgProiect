﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Cumparari
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public DetailsModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

      public Cumparare Cumparare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }

            var cumparare = await _context.Cumparare.FirstOrDefaultAsync(m => m.ID == id);
            if (cumparare == null)
            {
                return NotFound();
            }
            else 
            {
                Cumparare = cumparare;
            }
            return Page();
        }
    }
}
