using Ispit.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ispit.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Algebra.APIispit;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
