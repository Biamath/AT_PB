using AT_PB.Models;
using AT_PB.Services;
using AT_PB.Models.Enums;
using Microsoft.EntityFrameworkCore;


namespace AT_PB
{
	public class Program
	{
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração da string de conexão para SQLite
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<CsvService>();
            builder.Services.AddScoped<PedidoReembolsoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
            // Método para gerar o arquivo CSV
            private static void GerarCsv(CsvService csvService)
            {
            // Criando dados fictícios de exemplo
            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    UsuarioId = 1,
                    Nome = "João Silva",
                    Email = "joao.silva@email.com",
                    PedidosReembolso = new List<PedidoReembolso>
                    {
                        new PedidoReembolso
                        {
                          Id = 1,
                            DataSubmissao = DateTime.Now.AddDays(-5),
                           StatusPedidoId  = (int)DescricaoStatus.Pendente,
                            DespesasMedicas = new List<DespesaMedica>
                            {
                                new DespesaMedica { Id = 1, TipoDespesa = "Consulta médica", Valor = 250 },
                                new DespesaMedica { Id = 2,TipoDespesa = "Exame de sangue", Valor = 100 }
                            },
                            Documentos = new List<Documento>
                            {
                                new Documento { DocumentoId = 1, TipoDocumento = "Recibo", CaminhoArquivo = "/docs/recibo1.pdf" }
                            },
                            AnalisePedido = new AnalisePedido
                            {
                                Id = 1,
                                
                                Comentario = "Aguardando mais documentos",
                                DataAnalise = DateTime.Now
                            }
                        }
                    }
                }
            };

            // Gerando o arquivo CSV
            string filePath = "usuarios.csv"; // Caminho do arquivo CSV
            csvService.WriteCsv(filePath, usuarios); // Escrevendo os dados no CSV

            Console.WriteLine($"Arquivo CSV '{filePath}' gerado com sucesso!");
        }
    }
}


