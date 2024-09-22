namespace AT_PB.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string ?Email { get; set; }
        public string ?Telefone { get; set; }

        public List<PedidoReembolso>? PedidosReembolso { get; set; }= new List<PedidoReembolso>();
    }
}
