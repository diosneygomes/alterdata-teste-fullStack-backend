using Alterdata.TesteFullStackBackend.Api.V1.Controllers;
using Alterdata.TesteFullStackBackend.Api.V1.Requests.Product;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Alterdata.TesteFullStack.Tests.ProductTests
{
    public class ProductsControllerTests
    {
        private readonly ProdutcsController _controller;
        private readonly Mock<IProductService> _productServiceMock;

        public ProductsControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProdutcsController(_productServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfProducts()
        {

            var products = new List<ProductDTO> { new ProductDTO { Id = 1, Name = "Test Product", Price = 0.01m, Stock = 0 } };

            _productServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(products);

            var result = await _controller.GetAllAsync();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<List<ProductDTO>>(okResult.Value);

            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WhenGetProduct()
        {
            _productServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(true);

            _productServiceMock.Setup(service => service.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProductDTO { Id = 1, Name = "Test Product", Price = 0.01m, Stock = 0 });

            var result = await _controller.GetByIdAsync(1);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<ProductDTO>(okResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenProductDoesNotExist()
        {
            _productServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(false);

            var result = await _controller.GetByIdAsync(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBadRequest_WhenIdIsZero()
        {
            var result = await _controller.GetByIdAsync(0);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostProduct_ReturnsCreatedAtAction_WhenSuccessful()
        {
            _productServiceMock.Setup(service => service.CreateAsync(It.IsAny<ProductDTO>())).Returns(Task.CompletedTask);

            var result = await _controller.CreateAsync(new ProductPostRequest());

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task PutProduct_ReturnsOkResult_WhenSuccessful()
        {
            _productServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(true);

            _productServiceMock.Setup(service => service.UpdateAsync(It.IsAny<int>(), It.IsAny<ProductDTO>())).Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, new ProductPutRequest());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsBadRequest_WhenProductDoesNotExist()
        {
            var result = await _controller.UpdateAsync(It.IsAny<int>(), new ProductPutRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateProductAsync_ReturnsBadRequest_WhenIdIsZero()
        {
            var result = await _controller.UpdateAsync(0, new ProductPutRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsBadRequest_WhenClientDoesNotExist()
        {
            _productServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(false);

            var result = await _controller.DeleteAsync(1);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsBadRequest_WhenIdIsZero()
        {
            var result = await _controller.GetByIdAsync(0);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
