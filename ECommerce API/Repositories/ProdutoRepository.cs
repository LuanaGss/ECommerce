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
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            _context.SaveChanges();

        }

        public Produto BuscarPorId(int id)
        {
            // ToList() - Pegar Varios
            // FirstOrDefault - Traz o primeiro que encontrar, ou NULL

            // Expressão lambid: é uma função não nomeada.
            // context.Produtos - Acesse a tabela de Produtos do Contexto.
            // FirstOrDefault - Pegue o primeiro que encontrar.
            // Para cada produto P, me retorne aquele que tem o IdProduto igual ao id.
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1 - Encontrar o que eu quero excluir
            // Find - Procura pela chave primaria.
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if(produtoEncontrado == null)
            {
                throw new Exception();
            }
            //Caso encontre o produto, remova ele.
            _context.Produtos.Remove(produtoEncontrado);
            // Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
