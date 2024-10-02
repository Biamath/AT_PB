
using Microsoft.EntityFrameworkCore;

namespace AT_PB.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=data/PedidosReembolso.db");
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoReembolso> PedidosReembolso { get; set; }
        public DbSet<DespesaMedica> DespesasMedicas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
   
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<AnalisePedido> AnalisesPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento Um-para-Muitos
            modelBuilder.Entity<PedidoReembolso>()
                .HasMany(p => p.DespesasMedicas)
                .WithOne(d => d.PedidoReembolso)
                .HasForeignKey(d => d.PedidoReembolsoId);

            modelBuilder.Entity<PedidoReembolso>()
                .HasMany(p => p.Documentos)
                .WithOne(d => d.PedidoReembolso)
                .HasForeignKey(d => d.PedidoReembolsoId);

            // Relacionamento Um-para-Um
            modelBuilder.Entity<PedidoReembolso>()
                .HasOne(p => p.AnalisePedido)
                .WithOne(a => a.PedidoReembolso)
                .HasForeignKey<AnalisePedido>(a => a.PedidoReembolsoId);
        }
    }
}