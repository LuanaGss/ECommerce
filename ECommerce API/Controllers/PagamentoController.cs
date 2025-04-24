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
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        // 1 Definir o metodo
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }

        [HttpPost]

        public IActionResult CadastrarCliente(CadastrarPagamentoDto pag)
        {
            _pagamentoRepository.Cadastrar(pag);

            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            Pagamento pag = _pagamentoRepository.BuscarPorId(id);

            if (pag == null)
            {
                return NotFound();
            }

            return Ok(pag);
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, Pagamento pag)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pag);

                return Ok(pag);
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
                _pagamentoRepository.Deletar(id);

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
