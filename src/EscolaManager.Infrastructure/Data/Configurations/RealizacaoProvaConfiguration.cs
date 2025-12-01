using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class RealizacaoProvaConfiguration : IEntityTypeConfiguration<RealizacaoProva>
    {
        public void Configure(EntityTypeBuilder<RealizacaoProva> builder)
        {
            builder.ToTable("RealizacoesProvas");
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Prova)
                .WithMany()
                .HasForeignKey(r => r.ProvaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Bimestre)
                .WithMany()
                .HasForeignKey(r => r.BimestreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Avaliador)
                .WithMany()
                .HasForeignKey(r => r.AvaliadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Avaliado)
                .WithMany()
                .HasForeignKey(r => r.AvaliadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}