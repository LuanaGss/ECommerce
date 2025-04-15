using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;

namespace ECommerce_API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        // Injetar o Context
        // Injeção de Dependência
        private readonly EcommerceContext _context;

        // Ctor
        // Metodo Construtor
        // Quando criar um objeto o que eu preciso ter?
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
