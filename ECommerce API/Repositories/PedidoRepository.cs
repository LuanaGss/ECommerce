using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pedido pedido)
        {
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            if(pedidoEncontrado == null)
            {
                throw new Exception();
            }

            pedidoEncontrado.IdPedido = pedido.IdPedido;
            pedidoEncontrado.IdCliente = pedido.IdCliente;
            pedidoEncontrado.DataPedido = pedido.DataPedido;
            pedidoEncontrado.Status = pedido.Status;
            pedidoEncontrado.ValorTotal = pedido.ValorTotal;

            _context.SaveChanges();

        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
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
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            if(pedidoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pedidos.Remove(pedidoEncontrado);

            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItemPedidos)
                .ThenInclude(p => p.IdProdutoNavigation)
                .ToList();
        }
    }
}
