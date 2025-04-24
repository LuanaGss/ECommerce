using ECommerce_API.DTO;
using ECommerce_API.Models;

namespace ECommerce_API.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();

        Cliente BuscarPorId(int id);

        Cliente BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(CadastrarClienteDto cliente);

        void Atualizar(int id, Cliente cliente);

        void Deletar(int id);

        List<Cliente> BuscarClientePorNome(string nome);

    }
}
