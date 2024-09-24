using AT_PB.Models;

namespace AT_PB.Models
{

    public class DespesaMedica
    {
        public int Id { get; set; }
        public string? TipoDespesa { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDespesa { get; set; }
        public int PedidoReembolsoId { get; set; }

        // Relacionamento
        public PedidoReembolso? PedidoReembolso { get; set; }
    }

}



