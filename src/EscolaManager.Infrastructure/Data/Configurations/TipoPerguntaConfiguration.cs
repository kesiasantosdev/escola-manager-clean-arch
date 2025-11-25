using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class TipoPerguntaConfiguration : IEntityTypeConfiguration<TipoPergunta>
    {
        public void Configure(EntityTypeBuilder<TipoPergunta> builder)
        {
            builder.ToTable("TiposPerguntas");
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