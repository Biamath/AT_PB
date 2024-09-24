using AT_PB.Models;
using AT_PB.Models.Enums;

namespace AT_PB.Models
{


    public class StatusPedido
    {
        public int Id { get; set; }
        public string ?DescricaoStatus { get; set; }

        // Relacionamentos
        public ICollection<PedidoReembolso>? PedidosReembolso { get; set; }
    }

}
