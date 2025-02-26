using Alterdata.TesteFullStackBackend.Application.DTOS;

namespace Alterdata.TesteFullStackBackend.Application.Interfaces
{
    public interface IClientService
    {
        Task<bool> IsExistsAsync(int id);

        Task<ClientDTO> GetByIdAsync(int id);

        Task<IEnumerable<ClientDTO>> GetAllAsync();

        Task CreateAsync(ClientDTO client);

        Task UpdateAsync(int id, ClientDTO client);

        Task DeleteAsync(int id);
    }
}
