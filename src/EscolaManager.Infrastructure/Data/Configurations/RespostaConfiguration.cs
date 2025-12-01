using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class RespostaConfiguration : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("Respostas");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RespostaTexto).HasMaxLength(4000);

            builder.HasOne(r => r.RealizacaoProva)
                .WithMany()
                .HasForeignKey(r => r.RealizacaoProvaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}