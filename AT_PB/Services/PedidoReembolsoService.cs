
using LiteDB;
using System.Collections.Generic;
using System.Linq;

using AT_PB.Models;
using System.IO;


namespace AT_PB.Services
{

    public class PedidoReembolsoService
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public PedidoReembolsoService()
        {
            _dbPath = Path.Combine(Directory.GetCurrentDirectory(), "data", "PedidosReembolso.db");
            _connectionString = $"Filename={_dbPath};Connection=shared;";

            var directory = Path.GetDirectoryName(_dbPath);
            if (!Directory.Exists(directory))
            {
                // Criar o diretório se não existir
                Directory.CreateDirectory(directory);
            }
        }

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
}