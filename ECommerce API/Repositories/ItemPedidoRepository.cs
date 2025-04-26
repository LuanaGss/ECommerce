using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Repositories
{
    public class ItemPedidoRepository : IItemProdutoRepository
    {
        private readonly EcommerceContext _context;

        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, ItemPedido itemPedido)
        {
            ItemPedido itemEncontrado = _context.ItemPedidos.Find(id);

            if(itemEncontrado == null)
            {
                throw new Exception();
            }

            itemEncontrado.IdItemPedido = itemPedido.IdItemPedido;
            itemEncontrado.IdPedido = itemPedido.IdPedido;
            itemEncontrado.IdProduto = itemPedido.IdProduto;
            itemEncontrado.Quantidade = itemPedido.Quantidade;

            _context.SaveChanges();

        }

        public ItemPedido BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(i => i.IdItemPedido == id);
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            ItemPedido itemEncontrado = _context.ItemPedidos.Find(id);

            if(itemEncontrado == null)
            {
                throw new Exception();
            }

            _context.ItemPedidos.Remove(itemEncontrado);

            _context.SaveChanges();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
