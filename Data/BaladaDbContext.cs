
using ApiBalada.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data
{
    public class BaladaDbContext : DbContext
    {
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=app.db; Cache=Shared");
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfiguration(new ComandaMapping());
        //     modelBuilder.ApplyConfiguration(new PedidoMapping());
        //     modelBuilder.ApplyConfiguration(new FuncionarioMapping());
        //     modelBuilder.ApplyConfiguration(new Be());
        // }
    }
}
