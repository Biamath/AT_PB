
namespace AT_PB.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string ?Email { get; set; }
        public string ?Telefone { get; set; }
        public string ? Senha { get; set; }
       

        // Relacionamentos
        public ICollection<PedidoReembolso>? PedidosReembolso { get; set; }
        public ICollection<Notificacao>? Notificacoes { get; set; }
    }
}
