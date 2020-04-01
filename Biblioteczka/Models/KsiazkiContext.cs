using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public class KsiazkiContext : DbContext
    {
        public KsiazkiContext(DbContextOptions<KsiazkiContext> options)
            : base(options) { }

        public DbSet<Ksiazki> Ksiazkis { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
