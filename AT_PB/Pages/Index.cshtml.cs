using AT_PB.Models;
using AT_PB.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    private readonly CsvService _csvService;
    private readonly PedidoReembolsoService _pedidoReembolsoService;

    // Construtor onde ocorre a inje��o de depend�ncias
    public IndexModel(CsvService csvService, PedidoReembolsoService pedidoReembolsoService)
    {
        _csvService = csvService;
        _pedidoReembolsoService = pedidoReembolsoService;
    }

    // Propriedade para armazenar os pedidos de reembolso
    public List<PedidoReembolso> Pedidos { get; set; } = new List<PedidoReembolso>();

    // M�todo chamado quando a p�gina � carregada (GET)
    public void OnGet()
    {
        // Armazena um valor no ViewData
        ViewData["SomeProperty"] = "Some Value";

        // Gera o arquivo CSV ao carregar a p�gina
        _csvService.GerarCsv();

        // Recupera os pedidos armazenados no LiteDB e os atribui � propriedade Pedidos
        Pedidos = _pedidoReembolsoService.GetPedidos();
    }
}


