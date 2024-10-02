
    namespace AT_PB.Models
    {
        public class LayoutViewModel
        {
            public List<Usuario>? Usuarios { get; set; }
            public List<StatusPedido>? StatusPedidos { get; set; }
            public List<AnalisePedido>? AnalisePedidos { get; set; }
            public List<DespesaMedica> ?DespesasMedicas { get; set; }
            public List<Documento> ?Documentos { get; set; }
            public List<Notificacao>? Notificacoes { get; set; }
            public List<PedidoReembolso> ?PedidosReembolso { get; set; }
        }
    }
