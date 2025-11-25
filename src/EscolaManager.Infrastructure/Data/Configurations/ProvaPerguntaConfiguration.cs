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

            builder.HasKey(pp => new { pp.ProvaId, pp.PerguntaId });

            builder.HasOne(pp => pp.Prova)
                .WithMany(p => p.Questoes)
                .HasForeignKey(pp => pp.ProvaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Pergunta)
                .WithMany()
                .HasForeignKey(pp => pp.PerguntaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pp => pp.Ordem).IsRequired();
        }
    }
}