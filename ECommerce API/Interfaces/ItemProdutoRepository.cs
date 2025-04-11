using ECommerce_API.Models;

namespace ECommerce_API.Interfaces
{
    public interface ItemProdutoRepository
    {
        List<ItemPedido> ListarTodos();

        ItemPedido BuscarPorId(int id);

        void Cadastrar(ItemPedido itemPedido);

        void Atualizar(int id, ItemPedido itemPedido);

        void Deletar(int id);
    }
}