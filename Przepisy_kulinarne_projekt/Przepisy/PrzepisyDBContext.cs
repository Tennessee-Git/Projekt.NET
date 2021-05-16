using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przepisy_kulinarne_projekt.Przepisy
{
    public class PrzepisyDBContext : DbContext
    {
        public PrzepisyDBContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Przepis> Przepisy { get; set; }
    }
}
