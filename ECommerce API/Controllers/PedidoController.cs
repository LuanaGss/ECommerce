using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using ECommerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastroPedidoDto pedido)
        {
            _pedidoRepository.Cadastrar(pedido);

            return Created();
        }


        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            Pedido pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);

                return NoContent();
            }
            // caso de erro.
            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado");
            }
        }
    }
}
