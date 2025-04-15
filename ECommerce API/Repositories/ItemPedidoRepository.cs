using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Repositories
{
    public class ItemPedidoRepository : IItemProdutoRepository
    {
        private readonly EcommerceContext _context;
        public void Atualizar(int id, ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public ItemPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
