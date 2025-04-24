namespace ECommerce_API.DTO
{
    public class CadastrarPagamentoDto
    {
        public int IdPedido { get; set; }

        public string FormaPagamento { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime Data { get; set; }
    }
}
