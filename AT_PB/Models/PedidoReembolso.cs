
using AT_PB.Models.Enums;

namespace AT_PB.Models
{

    public class PedidoReembolso
    {
        public int PedidoReembolsoId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public ICollection<DespesaMedica>? DespesasMedicas { get; set; }
        public ICollection<Documento>? Documentos { get; set; }

        
        public int StatusPedidoId { get; set; }
        public StatusPedido Status { get; set; }

        
        public AnalisePedido? Analise { get; set; }
    }
}