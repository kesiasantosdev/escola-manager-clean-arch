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
            builder.Property(e => e.Cnpj).HasMaxLength(18).IsRequired();
        }
    }
}