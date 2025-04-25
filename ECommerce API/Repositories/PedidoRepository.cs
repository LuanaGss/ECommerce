using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;

namespace ECommerce_API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;
        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CadastroPedidoDto pedidoDto)
        {

            // Criando um Pedido.
            var pedido = new Pedido
            {
                DataPedido = pedidoDto.DataPedido,
                IdCliente = pedidoDto.IdCliente,
                Status = pedidoDto.Status,
                ValorTotal = pedidoDto.ValorTotal
            };

            // Adiciona no banco de dados e salva.
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            // Informa o i para cada produto.
            for (int i = 0; i < pedidoDto.Produto.Count; i++)
            {
                // Cria uma variavel que procura no _contexto cada i.
                var produto = _context.Produtos.Find(pedidoDto.Produto[i]);

                // Cria o item pedido.
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                // Adiciona no banco e salva.
                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.ToList();
        }
    }
}
