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