using ECommerce_API.Context;
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

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);

            _context.SaveChanges();
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
