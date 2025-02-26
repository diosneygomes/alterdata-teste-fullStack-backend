using Alterdata.TesteFullStackBackend.Application.DTOS;

namespace Alterdata.TesteFullStackBackend.Application.Interfaces
{
    public interface IProductService
    {
        Task<bool> IsExistsAsync(int id);

        Task<ProductDTO> GetByIdAsync(int id);

        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task CreateAsync(ProductDTO product);

        Task UpdateAsync(int id, ProductDTO product);

        Task DeleteAsync(int id);
    }
}
