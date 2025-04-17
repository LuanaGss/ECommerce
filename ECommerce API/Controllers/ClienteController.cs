using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using ECommerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]

        public IActionResult ListarCliente()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarCliente(Cliente client)
        {
            _clienteRepository.Cadastrar(client);

            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            Cliente client = _clienteRepository.BuscarPorId(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, Cliente client)
        {
            try
            {
                _clienteRepository.Atualizar(id, client);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return NotFound("Cliente não encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);

                return NoContent();
            }
            // caso de erro.
            catch (Exception ex)
            {
                return NotFound("Cliente não encontrado");
            }

        }
    }
}
