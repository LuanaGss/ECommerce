using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using ECommerce_API.Repositories;
using ECommerce_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        // Instanciar o PassWordServices
        private PasswordService passwordService = new PasswordService();

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Authorize] // So consegue fazer a consulta com o token 

        public IActionResult ListarCliente()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarCliente(CadastrarClienteDto client)
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

        [HttpPost("login")]

        public IActionResult Login(LoginDto login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if(cliente == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(cliente.Email);

            return Ok(token);
        }

        [HttpGet("/buscar/{nome}")]

        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }
    }
}
