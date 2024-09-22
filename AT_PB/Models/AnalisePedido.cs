namespace AT_PB.Models
{
    public class AnalisePedido
    {
        public int AnalisePedidoId { get; set; }
        public string? Analista { get; set; }
        public string? Comentarios { get; set; }
        public DateTime DataAnalise { get; set; }

        public int PedidoReembolsoId { get; set; }
        public PedidoReembolso? PedidoReembolso { get; set; }
    }

}
