using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(EcommerceContext context, IPagamentoRepository pagamentoRepository)
        {
            _context = context;
            _pagamentoRepository = pagamentoRepository;
        }

        // 1 Definir o metodo
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }
    }
}
