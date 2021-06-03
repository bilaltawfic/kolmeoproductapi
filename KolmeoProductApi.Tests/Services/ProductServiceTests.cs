using KolmeoProductApi.Models.Contexts;
using KolmeoProductApi.Services;
using KolmeoProductApi.Services.Exceptions;
using KolmeoProductApi.Services.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KolmeoProductApi.Tests.Services
{
    public class ProductServiceTests : BaseTestClass
    {
        private ProductService _productService;

        public ProductServiceTests()
            : base(
                new DbContextOptionsBuilder<KolmeoProductDbContext>()
                    .UseInMemoryDatabase("KolmeoProductApiTestDb")
                    .Options)
        {
            _productService = new ProductService(new KolmeoProductDbContext(ContextOptions));
        }

        [Fact]
        public void TestCreateProductSuccessfully()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = 19.99m,
            };

            var product = _productService.Create(options);

            Assert.NotNull(product);
        }

        [Fact]
        public async void TestCreateProductAsyncSuccessfully()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = 19.99m,
            };

            var product = await _productService.CreateAsync(options);

            Assert.NotNull(product);
        }

        [Fact]
        public void TestCreateProductNoNameThrowsException()
        {
            var options = new ProductCreateOptions()
            {
                Description = "A product description",
                Price = 19.99m,
            };

            Assert.Throws<RequiredFieldMissingException>(() => _productService.Create(options));
        }

        [Fact]
        public async void TestCreateProductAsyncNoNameThrowsException()
        {
            var options = new ProductCreateOptions()
            {
                Description = "A product description",
                Price = 19.99m,
            };

            await Assert.ThrowsAsync<RequiredFieldMissingException>(
                async () => await _productService.CreateAsync(options)
            );
        }

        [Fact]
        public void TestCreateProductInvalidPriceThrowsException()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = -0.01m,
            };

            Assert.Throws<InvalidFieldException>(() => _productService.Create(options));
        }

        [Fact]
        public async Task TestCreateProductAsyncInvalidPriceThrowsExceptionAsync()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = -0.01m,
            };

            await Assert.ThrowsAsync<InvalidFieldException>(
                async () => await _productService.CreateAsync(options)
            );
        }

        [Fact]
        public void TestGetProductSuccessfully()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = 19.99m,
            };

            var createdProduct = _productService.Create(options);

            var product = _productService.Get(createdProduct.Id);

            Assert.NotNull(product);
            Assert.Equal(createdProduct.Id, product.Id);
        }

        [Fact]
        public async Task TestGetProductAsyncSuccessfullyAsync()
        {
            var options = new ProductCreateOptions()
            {
                Name = "New product name",
                Description = "A product description",
                Price = 19.99m,
            };

            var createdProduct = _productService.Create(options);

            var product = await _productService.GetAsync(createdProduct.Id);

            Assert.NotNull(product);
            Assert.Equal(createdProduct.Id, product.Id);
        }

        [Fact]
        public void TestGetNonExistentProductSuccessfully()
        {
            var product = _productService.Get(new Guid());

            Assert.Null(product);
        }

        [Fact]
        public async void TestGetNonExistentProductAsyncSuccessfully()
        {
            var product = await _productService.GetAsync(new Guid());

            Assert.Null(product);
        }

        [Fact]
        public void TestGetAllProductsSuccessfully()
        {
            var numberOfProducts = 12;

            for (var i = 0; i < numberOfProducts; i++)
            {
                var options = new ProductCreateOptions()
                {
                    Name = "New product name",
                    Description = "A product description",
                    Price = 19.99m,
                };

                _productService.Create(options);
            }

            var listOptions = new ProductListOptions()
            { 
                PageNumber = 1,
                PageSize = 100,
            };

            var products = _productService.GetAll(listOptions);

            Assert.NotNull(products);
            Assert.Equal(numberOfProducts, products.Count());
        }

        [Fact]
        public async Task TestGetAllProductsAsyncSuccessfullyAsync()
        {
            var numberOfProducts = 12;

            for (var i = 0; i < numberOfProducts; i++)
            {
                var options = new ProductCreateOptions()
                {
                    Name = "New product name",
                    Description = "A product description",
                    Price = 19.99m,
                };

                _productService.Create(options);
            }

            var listOptions = new ProductListOptions()
            {
                PageNumber = 1,
                PageSize = 100,
            };

            var products = await _productService.GetAllAsync(listOptions);

            Assert.NotNull(products);
            Assert.Equal(numberOfProducts, products.Count());
        }
    }
}
