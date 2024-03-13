using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Category>().HasData(
            //     new Category { ID = 1, Name = "Category1", DisplayOrder = 1 },
            //     new Category { ID = 2, Name = "Category2", DisplayOrder = 2 },
            //     new Category { ID = 3, Name = "Category3", DisplayOrder = 3 }

            // );

            // modelBuilder.Entity<Product>().HasData(
            //     new Product { Id = 1, Title = "Title1", Description = "Description1", ISBN = "ISBN1", Author = "Author1", ListPrice = 20.0, Price = 30.0, Price50 = 40.0, Price100 = 50.0, CategordId = 1 },
            //     new Product { Id = 2, Title = "Title2", Description = "Description2", ISBN = "ISBN2", Author = "Author2", ListPrice = 20.0, Price = 30.0, Price50 = 40.0, Price100 = 50.0, CategordId = 2 }





            // );


        }




    }
}