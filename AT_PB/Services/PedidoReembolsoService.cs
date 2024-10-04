
using AT_PB.Models;
using Microsoft.EntityFrameworkCore;

namespace AT_PB.Services
{
    public class PedidoReembolsoService
    {
        private readonly AppDbContext _context;

        public PedidoReembolsoService(AppDbContext context)
        {
            _context = context;
        }

        public List<PedidoReembolso> GetPedidos()
        {
            return _context.PedidosReembolso.Include(p => p.DespesasMedicas)
                                            .Include(p => p.Documentos)
                                            .Include(p => p.AnalisePedido)
                                            .ToList();
        }

        public PedidoReembolso GetPedidoById(int id)
        {
            return _context.PedidosReembolso.Include(p => p.DespesasMedicas)
                                            .Include(p => p.Documentos)
                                            .Include(p => p.AnalisePedido)
                                            .FirstOrDefault(p => p.Id == id);
        }

        public void AddPedido(PedidoReembolso pedido)
        {
            _context.PedidosReembolso.Add(pedido);
            _context.SaveChanges();
        }

        public void UpdatePedido(PedidoReembolso pedido)
        {
            _context.PedidosReembolso.Update(pedido);
            _context.SaveChanges();
        }

        public void DeletePedido(int id)
        {
            var pedido = _context.PedidosReembolso.Find(id);
            if (pedido != null)
            {
                _context.PedidosReembolso.Remove(pedido);
                _context.SaveChanges();
            }
        }
    }
}
