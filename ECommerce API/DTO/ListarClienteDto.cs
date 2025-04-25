namespace ECommerce_API.DTO
{
    public class ListarClienteDto
    {
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }
    }
}
