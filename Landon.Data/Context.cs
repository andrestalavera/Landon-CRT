using System;
using Microsoft.EntityFrameworkCore;
using Landon.Models;

namespace Landon.Data
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Landon");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            // yyyy-MM-ddTHH:mm:ss
        }
    }
}
