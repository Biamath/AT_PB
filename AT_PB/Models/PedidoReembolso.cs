
using AT_PB.Models;
using AT_PB.Models.Enums;

namespace AT_PB.Models
{

    public class PedidoReembolso
    {


        public int Id { get; set; }
        public DateTime DataSubmissao { get; set; }
        public decimal ValorTotal { get; set; }
        public int StatusPedidoId { get; set; }
        public int UsuarioId { get; set; }

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public StatusPedido? StatusPedido { get; set; }
        public ICollection<DespesaMedica>? DespesasMedicas { get; set; }
        public ICollection<Documento>? Documentos { get; set; }
        public AnalisePedido? AnalisePedido { get; set; }
    }

}




