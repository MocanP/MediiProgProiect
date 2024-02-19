using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediiProgProiect.Models;

namespace MediiProgProiect.Data
{
    public class MediiProgProiectContext : DbContext
    {
        public MediiProgProiectContext (DbContextOptions<MediiProgProiectContext> options)
            : base(options)
        {
        }

        public DbSet<MediiProgProiect.Models.MasinaC> MasinaC { get; set; } = default!;

        public DbSet<MediiProgProiect.Models.Vanzator>? Vanzator { get; set; }

        public DbSet<MediiProgProiect.Models.Tip>? Tip { get; set; }

        public DbSet<MediiProgProiect.Models.Membru>? Membru { get; set; }

        public DbSet<MediiProgProiect.Models.Cumparare>? Cumparare { get; set; }
    }
}
