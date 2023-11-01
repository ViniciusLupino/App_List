using AppTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTarefas.Data
{
    public class AppTarefasDbContext : DbContext
    {
        public AppTarefasDbContext(DbContextOptions options) : base(options)
        {}

        public  DbSet<Categoria> Categorias { get; set; }
        public DbSet<Status> Status { get; set; }    
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("tbCategoria");
            modelBuilder.Entity<Status>().ToTable("tbStatus");
            modelBuilder.Entity<Tarefa>().ToTable("tbTarefa");
        }
    }
}
