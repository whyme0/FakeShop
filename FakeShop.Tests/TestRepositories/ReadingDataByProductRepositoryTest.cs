using FakeShop.Data;
using FakeShop.Models;
using FakeShop.Repositories;
using FakeShop.Tests.Tools;

namespace FakeShop.Tests.TestRepositories
{
    public class ReadingDataByProductRepositoryTest : ITestBase
    {
        protected readonly ProductRepository ProductRepository;
        protected readonly ShopDbContext DbContext;

        public ReadingDataByProductRepositoryTest()
        {
            DbContext = ShopDbContextFactory.CreateFor__ReadingDataByProductRepositoryTest();
            ProductRepository = new ProductRepository(DbContext);
        }

        public void Dispose()
        {
            ShopDbContextFactory.Delete(DbContext);
        }

        [Fact]
        public async Task TestGet_NotNull()
        {
            Product? product1 = await ProductRepository.Get(p => p.VendorCode == 312985);
            Product? product2 = await ProductRepository.Get(p => p.VendorCode == 312986);
            
            Assert.NotNull(product1);
            Assert.NotNull(product2);

            Assert.NotEqual(product1, product2);
        }

        [Fact]
        public async Task TestGetAll_NotEmpty()
        {
            var products = await ProductRepository.GetAll();

            Assert.NotEmpty(products);
            Assert.Equal(2, products.Count);
        }

        [Fact]
        public async void TestGetAndGetAll_NoData()
        {
            IList<Product> productsBeforeDeleteMethod = await ProductRepository.GetAll();
            await ProductRepository.Delete(productsBeforeDeleteMethod);

            // Get
            Product? product1 = await ProductRepository.Get(p => p.VendorCode == 312985);
            Product? product2 = await ProductRepository.Get(p => p.VendorCode == 312986);

            Assert.Null(product1);
            Assert.Null(product2);

            // GetAll
            var productsAfterDeleteOperation = await ProductRepository.GetAll();

            Assert.Empty(productsAfterDeleteOperation);
            Assert.Equal(0, productsAfterDeleteOperation.Count);
        }
    }
}
