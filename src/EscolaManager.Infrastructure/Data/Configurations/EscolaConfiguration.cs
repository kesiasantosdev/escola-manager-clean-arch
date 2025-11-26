using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class EscolaConfiguration : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.ToTable("Escolas");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NomeEscola).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Cnpj).HasMaxLength(14).IsRequired();
            builder.HasIndex(e => e.Cnpj).IsUnique();
            builder.Property(e => e.Email).HasMaxLength(150);
            builder.Property(e => e.Telefone).HasMaxLength(20);
            builder.Property(e => e.Cep).HasMaxLength(10);
            builder.Property(e => e.Rua).HasMaxLength(200);
            builder.Property(e => e.Numero).HasMaxLength(20);
            builder.Property(e => e.Bairro).HasMaxLength(100);
            builder.Property(e => e.Cidade).HasMaxLength(100);
            builder.Property(e => e.Estado).HasMaxLength(2);

            builder.Property(e => e.Status).IsRequired();
        }
    }
}