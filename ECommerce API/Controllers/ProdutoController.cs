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
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IProdutoRepository _produtoRepository;

        // Injecao de dependencia.
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto prod)
        {
            // 1 - Coloco o produto no banco de dados.
            _produtoRepository.Cadastrar(prod);

            // 2 - Retorno um resultado
            // 201 - Created
            return Created();
        }

        // Buscar produto pot id

        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, Produto prod)
        {
          try
            {
                _produtoRepository.Atualizar(id, prod);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                return NoContent();
            }
            // caso de erro.
            catch (Exception ex)
            {
                return NotFound("Produto nao encontrado");
            }
        }
    }

}
