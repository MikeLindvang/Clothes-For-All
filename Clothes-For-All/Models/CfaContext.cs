using Microsoft.EntityFrameworkCore;
using Clothes_For_All.Models;

namespace Clothes_For_All.Models
{
    public class CfaContext : DbContext
    {
        public CfaContext(DbContextOptions<CfaContext> options) : base(options) { }

        public DbSet<Kategori> Kategoris { get; set; }  
        public DbSet<ProduktType> ProduktTypes { get; set; }
        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Clothes_For_All.Models.Lager>? Lager { get; set; }
        public DbSet<Clothes_For_All.Models.Supplier>? Supplier { get; set; }

        
    }
}
