using ECommerce_API.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce_API.Services
{
    public class PasswordService
    {
        // PasswordHasher - PBKDF2

        private readonly PasswordHasher<Cliente> _hasher = new();

        // 1 - Gerar um Hash
        public string HashPassaword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }
        // 2 - Verificar o Hash
        public bool VerificarSenha(Cliente cliente, string SenhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, SenhaInformada);

            return resultado == PasswordVerificationResult.Success;
        }
    }
}
