using CsvHelper;
using System.Globalization;


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
    }
}
