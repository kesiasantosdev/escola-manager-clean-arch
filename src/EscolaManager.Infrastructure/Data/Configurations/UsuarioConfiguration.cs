using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);

            // Configurando as Chaves Estrangeiras (FKs)

            // 1. Usuario -> Pessoa
            builder.HasOne(u => u.Pessoa)
                .WithMany()
                .HasForeignKey(u => u.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Usuario -> Escola
            builder.HasOne(u => u.Escola)
                .WithMany()
                .HasForeignKey(u => u.EscolaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Usuario -> Cargo
            builder.HasOne(u => u.Cargo)
                .WithMany()
                .HasForeignKey(u => u.CargoId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. AUTO-RELACIONAMENTO (Chefe)
            builder.HasOne(u => u.Superior)
                .WithMany()
                .HasForeignKey(u => u.SuperiorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}