using BackendRentall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BackendRentall.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated(); // Skapa databas om den inte finns
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Bisell", Description = "Iphone", Price = 9000, ImageUrl = "/images/bisell.jpg", CreatedBy = "Admin" },
                new Product { Id = 2, Name = "Bosch", Description = "Asus", Price = 12000, ImageUrl = "/images/bosch.jpg", CreatedBy = "Admin" }
            );
        }
    }
}
