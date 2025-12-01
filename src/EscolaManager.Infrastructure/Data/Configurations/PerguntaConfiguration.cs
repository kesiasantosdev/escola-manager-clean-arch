using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.ToTable("Perguntas");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TextoPergunta)
                .IsRequired();

            builder.HasOne(p => p.Escola)
                .WithMany()
                .HasForeignKey(p => p.EscolaId);

            builder.HasOne(p => p.TipoPergunta)
                .WithMany()
                .HasForeignKey(p => p.TipoPerguntaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.TipoResposta)
                .WithMany()
                .HasForeignKey(p => p.TipoRespostaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}