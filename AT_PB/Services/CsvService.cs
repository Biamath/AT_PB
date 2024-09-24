using CsvHelper;
using System.Globalization;
using AT_PB.Models; // Certifique-se de que o namespace esteja correto para as classes


namespace AT_PB.Services
{
    public class CsvService
    {
        // Método para ler um arquivo CSV e retornar uma lista de objetos
        public IEnumerable<T> ReadCsv<T>(string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<T>().ToList();
                return records;
            }
            catch (FileNotFoundException ex)
            {
                // Tratamento específico para o caso do arquivo não ser encontrado
                throw new Exception($"Erro: O arquivo '{filePath}' não foi encontrado.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Tratamento para falta de permissões de leitura
                throw new Exception($"Erro: Acesso não autorizado ao arquivo '{filePath}'.", ex);
            }
            catch (Exception ex)
            {
                // Tratamento genérico para outros erros
                throw new Exception($"Erro ao ler o arquivo CSV: {ex.Message}", ex);
            }
        }

        // Método para escrever uma lista de objetos no formato CSV
        public void WriteCsv<T>(string filePath, IEnumerable<T> records)
        {
            try
            {
                using var writer = new StreamWriter(filePath);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csv.WriteRecords(records);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Tratamento para falta de permissões de escrita
                throw new Exception($"Erro: Acesso não autorizado para escrever no arquivo '{filePath}'.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                // Tratamento específico para diretórios não encontrados
                throw new Exception($"Erro: O diretório do arquivo '{filePath}' não foi encontrado.", ex);
            }
            catch (Exception ex)
            {
                // Tratamento genérico para outros erros
                throw new Exception($"Erro ao escrever no arquivo CSV: {ex.Message}", ex);
            }
        }

        // Método para gerar o arquivo CSV com dados de exemplo
        public void GerarCsv()
        {
            // Criando dados fictícios de exemplo
            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    UsuarioId = 1,
                    Nome = "João Silva",
                    Email = "joao.silva@email.com",
                    Telefone = "99999-9999",
                    Senha = "senha_criptografada", // Note que a senha deve estar criptografada no sistema real
                    PedidosReembolso = new List<PedidoReembolso>
                    {
                        new PedidoReembolso
                        {
                            Id = 1,
                            DataSubmissao = DateTime.Now.AddDays(-5),
                            ValorTotal = 350.00m,
                            StatusPedido = new StatusPedido { Id = 1, DescricaoStatus = "Pendente" },
                            DespesasMedicas = new List<DespesaMedica>
                            {
                                new DespesaMedica { Id = 1, TipoDespesa = "Consulta médica", Valor = 250.00m, DataDespesa = DateTime.Now.AddDays(-10) },
                                new DespesaMedica { Id = 2, TipoDespesa = "Exame de sangue", Valor = 100.00m, DataDespesa = DateTime.Now.AddDays(-9) }
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
            WriteCsv(filePath, usuarios); // Escrevendo os dados no CSV

            Console.WriteLine($"Arquivo CSV '{filePath}' gerado com sucesso!");
        }
    }
}
