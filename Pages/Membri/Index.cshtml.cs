using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Data;
using MediiProgProiect.Models;

namespace MediiProgProiect.Pages.Membri
{
    public class IndexModel : PageModel
    {
        private readonly MediiProgProiect.Data.MediiProgProiectContext _context;

        public IndexModel(MediiProgProiect.Data.MediiProgProiectContext context)
        {
            _context = context;
        }

        public IList<Membru> Membru { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Membru != null)
            {
                Membru = await _context.Membru.ToListAsync();
            }
        }
    }
}
