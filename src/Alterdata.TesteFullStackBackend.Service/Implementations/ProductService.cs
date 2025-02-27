using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Exceptions;
using Alterdata.TesteFullStackBackend.Application.Interfaces;

namespace Alterdata.TesteFullStackBackend.Service.Implementations
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _productRepository.IsExistsAsync(id);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new ProductNullException("Produto não foi encontrado.");
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            return productDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var productsDTO = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });

            return productsDTO.OrderBy(c => c.Id);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            var product = new Product(
                productDTO.Name,
                productDTO.Price,
                productDTO.Stock);

            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(int id, ProductDTO productDTO)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new ProductNullException("Produto não foi encontrado.");
            }

            product.Update(
                productDTO.Name,
                productDTO.Price,
                productDTO.Stock);

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new ProductNullException("Produto não foi encontrado.");
            }

            await _productRepository.DeleteAsync(id);
        }
    }
}
