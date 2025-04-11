using ECommerce_API.Models;

namespace ECommerce_API.Interfaces
{
    public interface IProdutoRepository
    {
        // R - Read (Leitura)
        // Retorno
        List<Produto> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente.
        Produto BuscarPorId(int id);

        //C - Create (Cadastro)
        void Cadastrar(Produto produto);

        // U - Update (Atualizacao)
        // Recebe um identificador para encontrar o produto, e recebe o Produto novo para subsituir o Antigo.
        void Atualizar(int id, Produto produto);

        // D - Delete (Delecao)
        // Recebo o identificador de quem eu quero deletar.
        void Deletar(int id);
    }
}
