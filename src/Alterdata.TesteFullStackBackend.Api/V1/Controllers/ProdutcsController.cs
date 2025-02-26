using Alterdata.TesteFullStackBackend.Api.V1.Requests.Product;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Exceptions;
using Alterdata.TesteFullStackBackend.Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Alterdata.TesteFullStackBackend.Api.V1.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/products")]
    public class ProdutcsController : Controller
    {
        private readonly IProductService _productService;

        public ProdutcsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var productsDTO = await _productService.GetAllAsync();

                return Ok(productsDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var isExists = await _productService.IsExistsAsync(id);

                if (!isExists)
                {
                    return NotFound();
                }

                var productsDTO = await _productService.GetByIdAsync(id);

                return Ok(productsDTO);
            }
            catch (ProductNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(ProductPostRequest request)
        {
            try
            {
                var productDTO = new ProductDTO
                {
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock
                };

                await _productService.CreateAsync(productDTO);

                return Created("", "");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductPutRequest request)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var isExists = await _productService.IsExistsAsync(id);

                if (!isExists)
                {
                    return BadRequest();
                }

                var productDTO = new ProductDTO
                {
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock
                };

                await _productService.UpdateAsync(
                    id,
                    productDTO);

                return Ok();
            }
            catch (ProductNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var isExists = await _productService.IsExistsAsync(id);

                if (!isExists)
                {
                    return BadRequest();
                }

                await _productService.DeleteAsync(id);

                return NoContent();
            }
            catch (ProductNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
