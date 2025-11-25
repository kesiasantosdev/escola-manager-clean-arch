using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class TipoRespostaConfiguration : IEntityTypeConfiguration<TipoResposta>
    {
        public void Configure(EntityTypeBuilder<TipoResposta> builder)
        {
            builder.ToTable("TiposRespostas");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(t => t.Escola)
                .WithMany()
                .HasForeignKey(t => t.EscolaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}