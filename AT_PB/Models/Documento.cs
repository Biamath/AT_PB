namespace AT_PB.Models
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public string? NomeArquivo { get; set; }
        public string? CaminhoArquivo { get; set; }
        public string? TipoDocumento { get; set; }

        public int PedidoReembolsoId { get; set; }
        public PedidoReembolso? PedidoReembolso { get; set; }
    }

}
