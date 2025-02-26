using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Exceptions;
using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Service.Implementations;
using Moq;

namespace Alterdata.TesteFullStack.Tests.ProductTests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfProducts()
        {
            var products = new List<Product>
            {
                new Product("Test Product - 1", 0.01m, 0),
                new Product("Test Product - 1", 0.01m, 0)
            };

            _productRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            var result = await _productService.GetAllAsync();

            Assert.Equal(2, result.Count());
            Assert.Contains(result, c => c.Name == "Test Product - 1");
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsProduct_WhenProductExists()
        {
            var product = new Product("Test Product - 1", 0.01m, 0);

            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

            var result = await _productService.GetByIdAsync(It.IsAny<int>());

            Assert.NotNull(result);

            Assert.Equal("Test Product - 1", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductIsNull()
        {
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Product)null);

            await Assert.ThrowsAsync<ProductNullException>(() => _productService.GetByIdAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task CreateAsync_WhenProductIsCreatedSuccessfully()
        {
            var productDto = new ProductDTO { Name = "Test Product - 1", Price = 0.01m, Stock = 0 };

            _productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            await _productService.CreateAsync(productDto);

            _productRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<Product>(c => c.Name == "Test Product - 1")), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WhenProductIsUpdatedSuccessfully()
        {
            var productDto = new ProductDTO { Name = "Test Product - 1", Price = 0.01m, Stock = 0 };

            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product("Test Product - 1", 0.01m, 0));

            _productRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            await _productService.UpdateAsync(1, productDto);

            _productRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Product>(c => c.Name == "Test Product - 1")), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WhenProductIsDeletedSuccessfully()
        {
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product("Test Product - 1", 0.01m, 0));

            _productRepositoryMock.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            await _productService.DeleteAsync(1);

            _productRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
