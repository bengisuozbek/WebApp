using System;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models;

namespace WebAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Electronics"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Cosmetics"
                    }, new Category
                    {
                        Id = 3,
                        Name = "Clothes"
                    });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "TV",
                        Price = 1000,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Iphone",
                        Price = 620,
                        CategoryId = 1
                    }, new Product
                    {
                        Id = 3,
                        Name = "Blush",
                        Price = 80,
                        CategoryId = 2
                    }, new Product
                    {
                        Id = 4,
                        Name = "Sweat",
                        Price = 65,
                        CategoryId = 3
                    }, new Product
                    {
                        Id = 5,
                        Name = "Lipstick",
                        Price = 120,
                        CategoryId = 2
                    }, new Product
                    {
                        Id = 6,
                        Name = "Tshirt",
                        Price = 10,
                        CategoryId = 3
                    }, new Product
                    {
                        Id = 7,
                        Name = "Skirt",
                        Price = 50,
                        CategoryId = 3
                    }, new Product
                    {
                        Id = 8,
                        Name = "Eyeliner",
                        Price = 1000,
                        CategoryId = 2,
                    });
            });
        }

    }
}







// 


