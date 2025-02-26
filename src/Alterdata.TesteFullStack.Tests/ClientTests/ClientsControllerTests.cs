using Alterdata.TesteFullStackBackend.Api.V1.Controllers;
using Alterdata.TesteFullStackBackend.Api.V1.Requests.Client;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Alterdata.TesteFullStack.Tests.ClientTests
{
    public class ClientsControllerTests
    {
        private readonly ClientsController _controller;
        private readonly Mock<IClientService> _clientServiceMock;

        public ClientsControllerTests()
        {
            _clientServiceMock = new Mock<IClientService>();
            _controller = new ClientsController(_clientServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfClients()
        {

            var clients = new List<ClientDTO> { new ClientDTO { Id = 1, Name = "Test Client", PhoneNumber = "(99) 99999-9999", Email = "testeclient@alterdata.com.br", Active = true } };

            _clientServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(clients);

            var result = await _controller.GetAllAsync();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<List<ClientDTO>>(okResult.Value);

            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WhenGetClient()
        {
            _clientServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(true);

            _clientServiceMock.Setup(service => service.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new ClientDTO { Id = 1, Name = "Test Client", PhoneNumber = "(99) 99999-9999", Email = "testeclient@alterdata.com.br", Active = true });

            var result = await _controller.GetByIdAsync(1);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsType<ClientDTO>(okResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenClientDoesNotExist()
        {
            _clientServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(false);

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
        public async Task PostClient_ReturnsCreatedAtAction_WhenSuccessful()
        {
            _clientServiceMock.Setup(service => service.CreateAsync(It.IsAny<ClientDTO>())).Returns(Task.CompletedTask);

            var result = await _controller.CreateAsync(new ClientPostRequest());

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task PutClient_ReturnsOkResult_WhenSuccessful()
        {
            _clientServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(true);

            _clientServiceMock.Setup(service => service.UpdateAsync(It.IsAny<int>(),It.IsAny<ClientDTO>())).Returns(Task.CompletedTask);
            
            var result = await _controller.UpdateAsync(1, new ClientPutRequest());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateClientAsync_ReturnsBadRequest_WhenClientDoesNotExist()
        {
            var result = await _controller.UpdateAsync(It.IsAny<int>(), new ClientPutRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateClientAsync_ReturnsBadRequest_WhenIdIsZero()
        {
            var result = await _controller.UpdateAsync(0, new ClientPutRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsBadRequest_WhenClientDoesNotExist()
        {
            _clientServiceMock.Setup(service => service.IsExistsAsync(It.IsAny<int>())).ReturnsAsync(false);

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
