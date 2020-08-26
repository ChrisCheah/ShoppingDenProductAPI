using Microsoft.EntityFrameworkCore;
using ShoppingDenProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDenProductAPI.Contexts
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>()
       .HasMany(c => c.ProductList)
       .WithOne(e => e.Catalog);
        }
    }
}
