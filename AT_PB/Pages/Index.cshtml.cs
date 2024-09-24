using AT_PB.Models;
using AT_PB.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class IndexModel(CsvService csvService, PedidoReembolsoService pedidoReembolsoService) : PageModel
{
    private readonly CsvService _csvService = csvService;
    private readonly PedidoReembolsoService _pedidoReembolsoService = pedidoReembolsoService;

    public List<PedidoReembolso> Pedidos { get; set; }

    public void OnGet()
    {
        // Gera o arquivo CSV ao carregar a página
        _csvService.GerarCsv();

        // Recupera os pedidos armazenados no LiteDB
        Pedidos = _pedidoReembolsoService.GetPedidos();
    }
}
