using Microsoft.EntityFrameworkCore;
using ContactManager.Models;
using System;

namespace ContactManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Family" },
                new Category { CategoryId = 2, CategoryName = "Friends" },
                new Category { CategoryId = 3, CategoryName = "Work" }
            );

            // Seed Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "1234567890", CategoryId = 3 },
                new Contact { Id = 2, FirstName = "Aziz", LastName = "Najjar", Email = "aziz@example.com", PhoneNumber = "0987654321", CategoryId = 2 },
                 new Contact { Id = 3, FirstName = "Alex", LastName = "Spakova", Email = "alex@example.com", PhoneNumber = "0987654321", CategoryId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
