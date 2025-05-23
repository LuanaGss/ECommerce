﻿using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using ECommerce_API.Services;

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

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();

            return listaClientes;
        }

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Procuro Cliente pelo email 
            var ClienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email);

            // Caso encontre, retorno nulo
            if(ClienteEncontrado == null)
                return null;

            var passwordService = new PasswordService();

            // Verificar se a senha do Usuario gera o mesmo Hash
            var resultado = passwordService.VerificarSenha
                (ClienteEncontrado, senha);

            if(resultado == true) return ClienteEncontrado;
                return null;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDto cliente)
        {
            var passwordService = new PasswordService();

            Cliente clienteCadastro = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Senha = cliente.Senha,
                DataCadastro = cliente.DataCadastro
            };

            clienteCadastro.Senha = passwordService.HashPassaword(clienteCadastro);

            _context.Clientes.Add(clienteCadastro);

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

        public List<ListarClienteDto> ListarTodos()
        {
            return _context.Clientes
                .Select(c => new ListarClienteDto
                {
                    IdCliente = c.IdCliente,
                    NomeCompleto = c.NomeCompleto,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco,
                })
                .ToList();
        }
    }
    
}
