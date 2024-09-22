using AT_PB.Models;
using AT_PB.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly CsvService _csvService;

    public IndexModel(CsvService csvService)
    {
        _csvService = csvService;
    }

    public void OnGet()
    {
        var records = _csvService.ReadCsv<Usuario>("path_to_csv_file.csv");
       
    }
}
