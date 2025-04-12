using ECommerce_API.Context;
using ECommerce_API.Interfaces;
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

        public ItemPedidoController(EcommerceContext context, IItemProdutoRepository itemPedidoRepository)
        {
            _context = context;
            _itemPedidoRepository = itemPedidoRepository;
        }
    }
}
