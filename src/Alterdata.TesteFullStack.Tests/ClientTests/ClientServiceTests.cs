using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Service.Implementations;
using Moq;
using Alterdata.TesteFullStackBackend.Application.Exceptions;

namespace Alterdata.TesteFullStack.Tests.ClientTests
{
    public class ClientServiceTests
    {
        private readonly ClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepositoryMock;

        public ClientServiceTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfClients()
        {
            var clients = new List<Client>
            {
                new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", true),
                new Client("Test Client - 2", "testeclient@alterdata.com.br", "(99) 99999-9999", true)
            };

            _clientRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clients);

            var result = await _clientService.GetAllAsync();

            Assert.Equal(2, result.Count());
            Assert.Contains(result, c => c.Name == "Test Client - 1");
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsClient_WhenClientExists()
        {
            var client = new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", true);

            _clientRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(client);

            var result = await _clientService.GetByIdAsync(It.IsAny<int>());

            Assert.NotNull(result);
            
            Assert.Equal("Test Client - 1", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenClientIsNull()
        {
            _clientRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Client)null);

            await Assert.ThrowsAsync<ClientNullException>(() => _clientService.GetByIdAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task CreateAsync_WhenClientIsCreatedSuccessfully()
        {
            var clientDto = new ClientDTO { Name = "Test Client - 1", Email = "testeclient@alterdata.com.br", PhoneNumber = "(99) 99999-9999", Active = true };
            
            _clientRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);

            await _clientService.CreateAsync(clientDto);

            _clientRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<Client>(c => c.Name == "Test Client - 1")), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WhenClientIsUpdatedSuccessfully()
        {
            var clientDto = new ClientDTO { Name = "Test Client - 1", Email = "testeclient@alterdata.com.br", PhoneNumber = "(99) 99999-9999", Active = true };

            _clientRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", true));

            _clientRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);

            await _clientService.UpdateAsync(1, clientDto);

            _clientRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Client>(c => c.Name == "Test Client - 1")), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WhenClientIsDeletedSuccessfully()
        {
            _clientRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Client("Test Client - 1", "testeclient@alterdata.com.br", "(99) 99999-9999", true));

            _clientRepositoryMock.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            await _clientService.DeleteAsync(1);

            _clientRepositoryMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }
    }
}
