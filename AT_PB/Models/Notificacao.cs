using AT_PB.Models;

namespace AT_PB.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string? Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
        public int UsuarioId { get; set; }
        public string? TipoNotificacao { get; set; }

        // Relacionamento
        public Usuario? Usuario { get; set; }
    }

}





