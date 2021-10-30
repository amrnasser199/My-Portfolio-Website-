using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infrastructure
{
    public class AmrContext : DbContext
    {
        public AmrContext() : base()
        {

        }

        public AmrContext(DbContextOptions<AmrContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionStrings");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Portfolio_Item>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    AvatarImage = "amr bdla.jpg",
                    FullName = "Amr Nasser",
                    Profile = ".Net Developer/DB Adminstrator"
                }
                );
        }
        public DbSet<Owner> owner { get; set; }
        public DbSet<Portfolio_Item> portfolio_Item { get; set; }

    }
}
