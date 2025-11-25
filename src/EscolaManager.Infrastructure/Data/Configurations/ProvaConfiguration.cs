using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class ProvaConfiguration : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.ToTable("Provas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo).HasMaxLength(200).IsRequired();

            builder.HasOne(p => p.UsuarioCriador)
                .WithMany()
                .HasForeignKey(p => p.UsuarioCriadorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}