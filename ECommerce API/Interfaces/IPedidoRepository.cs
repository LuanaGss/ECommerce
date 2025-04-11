using ECommerce_API.Models;

namespace ECommerce_API.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarTodos();

        Pedido BuscarPorId(int id);

        void Cadastrar(Pedido pedido);

        void Atualizar(int id, Pedido pedido);

        void Deletar(int id);
    }
}
