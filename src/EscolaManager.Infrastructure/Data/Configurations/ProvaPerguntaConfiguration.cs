using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class ProvaPerguntaConfiguration : IEntityTypeConfiguration<ProvaPergunta>
    {
        public void Configure(EntityTypeBuilder<ProvaPergunta> builder)
        {
            builder.ToTable("ProvaPerguntas");

            // CHAVE COMPOSTA
            builder.HasKey(pp => new { pp.ProvaId, pp.PerguntaId });

            // RELACIONAMENTO COM PROVA
            builder.HasOne(pp => pp.Prova)
                   .WithMany(p => p.Questoes)
                   .HasForeignKey(pp => pp.ProvaId);

            // RELACIONAMENTO COM PERGUNTA
            builder.HasOne(pp => pp.Pergunta)
                   .WithMany() // se quiser criar coleção do outro lado, mude aqui
                   .HasForeignKey(pp => pp.PerguntaId);

            builder.Property(pp => pp.Ordem)
                   .IsRequired();
        }
    }
}
