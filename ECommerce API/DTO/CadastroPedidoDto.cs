namespace ECommerce_API.DTO
{
    // Recebo os dados do Pedido
    // E recebo os produtos comprados
    public class CadastroPedidoDto
    {
        public DateOnly? DataPedido { get; set; }
        public string? Status { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? IdCliente { get; set; }
        public List<int> Produto { get; set; }
        public List<int> Quantidades { get; set; }
    }
}
