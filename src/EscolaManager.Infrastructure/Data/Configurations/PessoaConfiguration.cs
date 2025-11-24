using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomePessoa)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();


            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.SenhaHash)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}