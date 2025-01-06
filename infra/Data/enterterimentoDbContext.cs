using Microsoft.EntityFrameworkCore;

namespace infra.Data
{
    public class enterterimentoDbContext : DbContext
    {
        public enterterimentoDbContext (DbContextOptions<enterterimentoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
