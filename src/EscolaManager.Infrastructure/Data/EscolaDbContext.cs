using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EscolaManager.Infrastructure.Data
{
    public class EscolaDbContext : DbContext
    {
        public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options)
        {
        }

        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<TipoPergunta> TiposPerguntas { get; set; }
        public DbSet<TipoResposta> TiposRespostas { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Prova> Provas { get; set; }
        public DbSet<Bimestre> Bimestres { get; set; }
        public DbSet<RealizacaoProva> RealizacoesProvas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
