using AT_PB.Models;

namespace AT_PB.Models
{
    public class AnalisePedido
    {
        
            public int Id { get; set; }
            public string ? Comentario { get; set; }
            public DateTime DataAnalise { get; set; }
            public int PedidoReembolsoId { get; set; }

            // Relacionamento
            public PedidoReembolso? PedidoReembolso { get; set; }
        }

    }






