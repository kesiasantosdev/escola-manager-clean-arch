using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EscolaManager.Infrastructure.Data
{
    public class EscolaDbContextFactory : IDesignTimeDbContextFactory<EscolaDbContext>
    {
        public EscolaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EscolaDbContext>();

            // Configuração direta para a Migration funcionar sem depender da API
            optionsBuilder.UseSqlServer("Server=localhost;Database=EscolaManagerDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new EscolaDbContext(optionsBuilder.Options);
        }
    }
}