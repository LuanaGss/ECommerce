using ECommerce_API.DTO;
using ECommerce_API.Models;

namespace ECommerce_API.Interfaces
{
    public interface IPagamentoRepository
    {
        List<Pagamento> ListarTodos();

        Pagamento BuscarPorId(int id);

        void Cadastrar(CadastrarPagamentoDto pagamento);

        void Atualizar(int id, Pagamento pagamento);

        void Deletar(int id);
    }
}
