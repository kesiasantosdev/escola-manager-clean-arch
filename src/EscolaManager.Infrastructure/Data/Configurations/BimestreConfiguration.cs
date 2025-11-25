using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class BimestreConfiguration : IEntityTypeConfiguration<Bimestre>
    {
        public void Configure(EntityTypeBuilder<Bimestre> builder)
        {
            builder.ToTable("Bimestres");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Titulo).HasMaxLength(100).IsRequired();

            builder.HasOne(b => b.UsuarioGestor)
                .WithMany()
                .HasForeignKey(b => b.UsuarioGestorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}