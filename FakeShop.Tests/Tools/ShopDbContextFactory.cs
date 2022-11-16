using FakeShop.Data;
using FakeShop.Models;
using FakeShop.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FakeShop.Tests.Tools
{
    public class ShopDbContextFactory
    {
        public static ShopDbContext CreateFor__ReadingDataByProductRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase("test__fakeshop_db")
                .Options;

            var context = new ShopDbContext(options);

            context.Database.EnsureCreated();

            context.AddRange(
                new Product()
                {
                    VendorCode = 312985,
                    Name = "Super thing 1",
                    Description = "This is the best super thing 1 ever",
                    IsSelling = false,
                    IsHidden = false,
                    CurrentPrice = 17.3,
                    Quantity = 250
                },
                new Product()
                {
                    VendorCode = 312986,
                    Name = "Super thing 2",
                    Description = "This is the best super thing 2 ever",
                    IsSelling = false,
                    IsHidden = false,
                    CurrentPrice = 17.3,
                    Quantity = 250
                }
            );

            context.SaveChanges();

            return context;
        }

        public static ShopDbContext CreateFor__WritingDataByProductRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase("test__fakeshop_db")
                .Options;

            var context = new ShopDbContext(options);

            context.Database.EnsureCreated();
            
            var productWithRelations = new Product()
            {
                VendorCode = 100000,
                Name = "Name",
                Description = "Description",
                IsSelling = false,
                IsHidden = false,
                CurrentPrice = 1,
                Quantity = 1
            };

            context.AddRange(
                new Product() // for delete
                {
                    VendorCode = 312985,
                    Name = "Name",
                    Description = "Description",
                    IsSelling = false,
                    IsHidden = false,
                    CurrentPrice = 1,
                    Quantity = 1
                },
                new Product() // for delete also relations
                {
                    VendorCode = 312986,
                    Name = "Name",
                    Description = "Description",
                    IsSelling = false,
                    IsHidden = false,
                    CurrentPrice = 1,
                    Quantity = 1
                },
                productWithRelations // for create & edit
            );

            context.AddRange(
                new ProductImage() { ImagePath = "/path/img1.png", ProductId = productWithRelations.Id, Product = productWithRelations },
                new ProductImage() { ImagePath = "/path/img2.png", ProductId = productWithRelations.Id, Product = productWithRelations }
            );

            context.SaveChanges();

            return context;
        }

        public static void Delete(ShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
