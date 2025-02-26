using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Exceptions;
using Alterdata.TesteFullStackBackend.Application.Interfaces;

namespace Alterdata.TesteFullStackBackend.Service.Implementations
{
    public sealed class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _clientRepository.IsExistsAsync(id);
        }

        public async Task<ClientDTO> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client is null)
            {
                throw new ClientNullException("Cliente não foi encontrado.");
            }

            var clientDTO = new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber
            };

            return clientDTO;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();

            var clientsDTO = clients.Select(c => new ClientDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            });

            return clientsDTO;
        }

        public async Task CreateAsync(ClientDTO clientDTO)
        {
            var client = new Client(
                clientDTO.Name,
                clientDTO.Email,
                clientDTO.PhoneNumber,
                clientDTO.Active);

            await _clientRepository.CreateAsync(client);
        }

        public async Task UpdateAsync(int id, ClientDTO clientDTO)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client is null)
            {
                throw new ClientNullException("Cliente não foi encontrado.");
            }

            client.Update(
                clientDTO.Name,
                clientDTO.Email,
                clientDTO.PhoneNumber,
                clientDTO.Active);

            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client is null)
            {
                throw new ClientNullException("Cliente não foi encontrado.");
            }

            await  _clientRepository.DeleteAsync(id);
        }
    }
}
