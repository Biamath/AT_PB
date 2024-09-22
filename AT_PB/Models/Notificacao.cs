namespace AT_PB.Models
{
    public class Notificacao
    {
        public int NotificacaoId { get; set; }
        public string? Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }

}
