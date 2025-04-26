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
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IItemProdutoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemProdutoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]

        public IActionResult ListarItem()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarItemPedido(ItemPedido item)
        {
            _itemPedidoRepository.Cadastrar(item);

            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            ItemPedido item = _itemPedidoRepository.BuscarPorId(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, ItemPedido item)
        {
            try
            {
                _itemPedidoRepository.Atualizar(id, item);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound("Item de pedido não encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _itemPedidoRepository.Deletar(id);

                return NoContent();
            }
            // caso de erro.
            catch (Exception ex)
            {
                return NotFound("Item de pedido não encontrado");
            }

        }
    }
}
