using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profesorii_Meditati.Models;

namespace Profesorii_Meditati.Data
{
    public class Profesorii_MeditatiContext : DbContext
    {
        public Profesorii_MeditatiContext (DbContextOptions<Profesorii_MeditatiContext> options)
            : base(options)
        {
        }

        public DbSet<Profesorii_Meditati.Models.Student> Student { get; set; } = default!;
        public DbSet<Profesorii_Meditati.Models.Profesor> Profesor { get; set; } = default!;
        public DbSet<Profesorii_Meditati.Models.Meditatie> Meditatie { get; set; } = default!;
        public DbSet<Profesorii_Meditati.Models.Programare> Programare { get; set; } = default!;
        public DbSet<Profesorii_Meditati.Models.Recenzie> Recenzie { get; set; } = default!;
    }
}
