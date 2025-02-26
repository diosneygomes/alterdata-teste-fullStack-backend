using Alterdata.TesteFullStackBackend.Api.V1.Requests.Client;
using Alterdata.TesteFullStackBackend.Application.DTOS;
using Alterdata.TesteFullStackBackend.Application.Exceptions;
using Alterdata.TesteFullStackBackend.Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Alterdata.TesteFullStackBackend.Api.V1.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/clients")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var clientsDTO = await _clientService.GetAllAsync();

                return Ok(clientsDTO);
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

                var isExists = await _clientService.IsExistsAsync(id);

                if (!isExists)
                {
                    return NotFound();
                }

                var clientsDTO = await _clientService.GetByIdAsync(id);

                return Ok(clientsDTO);
            }
            catch (ClientNullException e)
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
        public async Task<IActionResult> CreateAsync(ClientPostRequest request)
        {
            try
            {
                var clientDTO = new ClientDTO
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Active = request.Active
                };

                await _clientService.CreateAsync(clientDTO);

                return Created("", "");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, ClientPutRequest request)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var isExists = await _clientService.IsExistsAsync(id);

                if (!isExists)
                {
                    return BadRequest();
                }

                var clientDTO = new ClientDTO
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Active = request.Active
                };

                await _clientService.UpdateAsync(
                    id,
                    clientDTO);

                return Ok();
            }
            catch (ClientNullException e)
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

                var isExists = await _clientService.IsExistsAsync(id);

                if (!isExists)
                {
                    return BadRequest();
                }

                await _clientService.DeleteAsync(id);

                return NoContent();
            }
            catch (ClientNullException e)
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
