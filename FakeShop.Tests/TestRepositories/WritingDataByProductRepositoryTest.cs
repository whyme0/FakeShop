using FakeShop.Data;
using FakeShop.Models;
using FakeShop.Repositories;
using FakeShop.Tests.Tools;

namespace FakeShop.Tests.TestRepositories
{
    public class WritingDataByProductRepositoryTest : ITestBase
    {
        protected readonly ProductRepository ProductRepository;
        protected readonly ShopDbContext DbContext;

        public WritingDataByProductRepositoryTest()
        {
            DbContext = ShopDbContextFactory.CreateFor__WritingDataByProductRepositoryTest();
            ProductRepository = new ProductRepository(DbContext);
        }

        public void Dispose()
        {
            ShopDbContextFactory.Delete(DbContext);
        }

        [Fact]
        public async Task TestDelete_ReturnsTrue()
        {
            Product? product = await ProductRepository.Get(p => p.VendorCode == 312985);

            Assert.NotNull(product);
            
            bool result = await ProductRepository.Delete(product.Id);

            Assert.True(result);

            product = await ProductRepository.Get(p => p.VendorCode == 312985);

            Assert.Null(product);
        }

        [Fact]
        public async Task TestDelete_NotFound_ReturnsFalse()
        {
            bool result = await ProductRepository.Delete(1000);

            Assert.False(result);
        }

        //[Fact]
        //public async Task TestDelete_AlsoDeletesChildrenRelations()
        //{
        //    Product? product = await ProductRepository.Get(p => p.VendorCode == 312986);
        //    var productImages = await ProductImagesRepository.Get(p => p.ProductId == product!.Id);

        //    Assert.Equal(productImages.Count, 2);

        //    bool result = await ProductRepository.Delete(product.Id);

        //    Assert.True(result);

        //    productImages = await ProductImagesRepository.Get(p => p.ProductId == product.Id);

        //    Assert.Empty(productImages);
        //}

        //[Fact]
        //public async Task TestCreate_DefaultBehavior_ReturnsTrue()
        //{
        //    Product p = new Product()
        //    {
        //        VendorCode = 100001,
        //        Name = "Name",
        //        Description = "Description",
        //        IsSelling = false,
        //        IsHidden = false,
        //        CurrentPrice = 1,
        //        Quantity = 1
        //    };
            
        //    var productImages = new List<ProductImage>
        //    {
        //        new ProductImage() { ImagePath = "/path/imgx.png", ProductId = p.Id, Product = p },
        //        new ProductImage() { ImagePath = "/path/imgy.png", ProductId = p.Id, Product = p }
        //    };

        //    bool result = await ProductRepository.Create(p, productImages);

        //    Assert.True(result);

        //    Assert.Contains(productImages, ProductImagesRepository.Get(p => p.ProductId == product.Id));
        //}

        [Fact]
        public async Task TestCreate_AttemptToCreateDuplicateModel_ReturnsFalse()
        {
            Product p = new Product()
            {
                VendorCode = 100000,
                Name = "Name",
                Description = "Description",
                IsSelling = false,
                IsHidden = false,
                CurrentPrice = 1,
                Quantity = 1
            };

            bool result = await ProductRepository.Create(p);

            Assert.False(result);
        }

        [Fact]
        public async Task TestEdit_DefaultBehavior_ReturnsTrue()
        {
            Product? p = await ProductRepository.Get(p => p.VendorCode == 100000);
            string previousName = p.Name;
            p.Name = "Name edited";

            bool result = await ProductRepository.Update(p);

            Assert.True(result);

            p = await ProductRepository.Get(p => p.VendorCode == 100000);
            Assert.NotEqual(p.Name, previousName);
        }

        [Fact]
        public async Task TestEdit_TryEditUnchangableField_ReturnsFalse()
        {
            Product? p = await ProductRepository.Get(p => p.VendorCode == 100000);
            p.VendorCode = 100001;

            bool result = await ProductRepository.Update(p);

            Assert.False(result);

            p = await ProductRepository.Get(p => p.VendorCode == 100000);
            Assert.Equal(100000, p.VendorCode);
        }
    }
}
