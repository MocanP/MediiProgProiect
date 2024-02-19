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
    public class IndexModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public IndexModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IList<Tip> Tip { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tip != null)
            {
                Tip = await _context.Tip.ToListAsync();
            }
        }
    }
}
