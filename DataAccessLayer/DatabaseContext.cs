using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>()
                .HasKey(p => p.Id);
        }
    }
}

