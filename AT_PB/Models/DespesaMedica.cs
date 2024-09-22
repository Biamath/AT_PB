namespace AT_PB.Models
{
    public class DespesaMedica
    {
        public int DespesaMedicaId { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }

        public int PedidoReembolsoId { get; set; }
        public PedidoReembolso? PedidoReembolso { get; set; }
    }

}
