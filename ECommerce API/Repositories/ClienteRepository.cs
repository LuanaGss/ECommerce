using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;

namespace ECommerce_API.Repositories
{
    // 1 - Herdar da Interface
    // 2 - Implementa a Interface
    // 3 - Injetar o Contexto
    public class ClienteRepository : IClienteRepository
    {
        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if(clienteEncontrado == null)
            {
                throw new Exception();
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();

        }

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            var ClienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return ClienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if(clienteEncontrado == null)
            {
                throw new Exception();
            }

            _context.Clientes.Remove(clienteEncontrado);

            _context.SaveChanges();

        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
    
}
