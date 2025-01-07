using filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace infra.Data
{
    public class enterterimentoDbContext : DbContext
    {
        public enterterimentoDbContext (DbContextOptions<enterterimentoDbContext> options) : base(options) { }

        public DbSet<UsuariosModel> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosModel>().ToTable("Usuarios");
        }
    }
}
