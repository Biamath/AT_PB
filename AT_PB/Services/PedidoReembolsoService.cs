
using AT_PB.Models;
using LiteDB;

public class PedidoReembolsoService
{
    private readonly string _dbPath = @"C:\Users\USUARIO\source\repos\AT_PB\AT_PB\data\PedidosReembolso.db";
    private readonly string _connectionString = @"Filename=data/PedidosReembolso.db;Connection=shared;";

    public PedidoReembolsoService()
    {
        // Verifica se o _dbPath é nulo ou inválido
        if (!string.IsNullOrWhiteSpace(_dbPath))
        {
            var directory = Path.GetDirectoryName(_dbPath);

            // Verifica se o 'directory' não é nulo
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            {
                // Criar o diretório se não existir
                Directory.CreateDirectory(directory);
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(_dbPath), "O caminho do banco de dados não pode ser nulo ou vazio.");
        }
    }

    // Demais métodos da classe
    public List<PedidoReembolso> GetPedidos()
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var pedidos = db.GetCollection<PedidoReembolso>("pedidos");
            return pedidos.FindAll().ToList();
        }
    }

    public PedidoReembolso GetPedidoById(int id)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var pedidos = db.GetCollection<PedidoReembolso>("pedidos");
            return pedidos.FindById(id);
        }
    }

    public void AddPedido(PedidoReembolso pedido)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var pedidos = db.GetCollection<PedidoReembolso>("pedidos");
            pedidos.Insert(pedido);
        }
    }

    public void UpdatePedido(PedidoReembolso pedido)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var pedidos = db.GetCollection<PedidoReembolso>("pedidos");
            pedidos.Update(pedido);
        }
    }

    public void DeletePedido(int id)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var pedidos = db.GetCollection<PedidoReembolso>("pedidos");
            pedidos.Delete(id);
        }
    }
}
